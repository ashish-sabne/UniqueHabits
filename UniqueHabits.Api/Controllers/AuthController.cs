using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Domain.Aggregates;

namespace UniqueHabits.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(UserManager<AppUser> userManager, IConfiguration config, IMapper mapper)
        {
            _userManager = userManager;
            _config = config;
            _mapper = mapper;
        }

        [Route("api/register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return BadRequest("User already exists");

            var user = AppUser.Create(model.FirstName, model.LastName, model.Email, model.EnableNotifications);

            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(errors);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                var auth = _mapper.Map<AuthUserModel>(user);
                auth.Token = new JwtSecurityTokenHandler().WriteToken(token);
                auth.ExpiryDate = token.ValidTo;
                
                return Ok(auth);
            }
            return Unauthorized();

        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtSecurityKey")));

            var token = new JwtSecurityToken(
                issuer: _config.GetValue<string>("JwtIssuer"),
                audience: _config.GetValue<string>("JwtAudience"),
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
