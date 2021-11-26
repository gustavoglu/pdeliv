using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectDeliv.Domain.Notifications;

namespace ProjectDeliv.Services.Api.Controllers.v1
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        protected readonly IMediator Mediator;
        public BaseController(IMediator mediator, INotificationHandler<DomainNotification> notifications)
        {
            Mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected IActionResult ResponseDefault(object? data = null)
        {
            if (_notifications.HasNotification())
            {
                return BadRequest(new { Success = false, Data = GetNotificationsToKeyValuePair()  });
            }

            return Ok(new { Success = true, Data = data });
        }


        protected List<KeyValuePair<string, string>> GetNotificationsToKeyValuePair()
        {
            return _notifications.Notifications.Select(notification => new KeyValuePair<string, string>(notification.Type, notification.Value)).ToList();
        }
    }
}
