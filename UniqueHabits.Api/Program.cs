using Microsoft.EntityFrameworkCore;
using UniqueHabits.Data;
using UnqiueHabits.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HabitsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HabitsDbConnection"),
        options => options.EnableRetryOnFailure(maxRetryCount: 5,
					maxRetryDelay: TimeSpan.FromSeconds(30),
					errorNumbersToAdd: null));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
