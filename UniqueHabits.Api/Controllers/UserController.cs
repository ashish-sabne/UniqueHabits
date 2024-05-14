using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Data;
using UniqueHabits.Shared.User;

namespace UniqueHabits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly HabitsContext _context;
        private readonly IUser _user;

        public UserController(HabitsContext context, IUser user)
        {
            _context = context;
            _user = user;
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePreferences([FromBody]AuthUserModel model)
        {
            if (!_user.Id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var user = await _context.Users.FindAsync(_user.Id.ToString());

                if (user == null)
                {
                    return NotFound();
                }

                user.Update(model.FirstName, model.LastName, model.EnableNotifications);

                _context.Users.Update(user);

                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            
        }
    }
}
