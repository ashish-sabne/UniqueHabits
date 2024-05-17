using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Data;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.User;

namespace UniqueHabits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly HabitsContext _context;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public NotificationsController(HabitsContext context, IMapper mapper, IUser user)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
        }

        [HttpGet]
        public IActionResult GetMyNotifications()
        {
            if (!_user.Id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var notifications = _context.Notifications.Where(IsByCurrentUser).AsQueryable().ToList();

                if (notifications == null || !notifications.Any())
                {
                    return NotFound();
                }
                var models = _mapper.Map<List<NotificationModel>>(notifications);

                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("{notificationId}/mark-as-read")]
        public async Task<IActionResult> MarkAsRead([FromRoute] Guid notificationId)
        {
            var notification = _context.Notifications.Where(IsByCurrentUser).AsQueryable()
                        .FirstOrDefault(n => n.Id == notificationId);

            if (notification == null)
            {
                return NotFound();
            }
            else
            {
                notification.MarkAsRead();
                _context.Notifications.Update(notification);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }


        private bool IsByCurrentUser(Notification notification)
        {
            return notification.CreatedById != null 
                && notification.CreatedById.ToLower() == _user.Id.GetValueOrDefault().ToString().ToLower();
        }
    }
}
