using ebuy.Domain.DTOs.ResponseBase;
using ebuy.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ebuy.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly DomainSuccesNotificationHandler _succesNotifications;
        private readonly IMediator _mediator;

        protected ControllerBase(INotificationHandler<DomainNotification> notifications,
                                 INotificationHandler<DomainSuccesNotification> succesNotification,
                                 IMediator mediator)
        {
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
            _succesNotifications = (DomainSuccesNotificationHandler)succesNotification;
        }

        protected bool ValidOperation()
        {
            return !_notifications.HasNotification();
        }

        protected IEnumerable<string> GetErrorMessages()
        {
            return _notifications.GetNotifications().Select(n => n.Value).ToList();
        }

        protected IEnumerable<string> GetSuccesMessages()
        {
            return _succesNotifications.GetNotifications().Select(n => n.Value).ToList();
        }

        protected void NotifyError(string cod, string message)
        {
            _mediator.Publish(new DomainNotification(cod, message));
        }

        protected new IActionResult Response(object? result = null)
        {
            if(ValidOperation())
            {
                return Ok(new OkResponseDTO
                {
                    Data = result,
                    Message = GetSuccesMessages()
                });
            }

            return BadRequest(new BadRequestResponseDTO
            {
                Errors = GetErrorMessages(),
                Data = result
            });
        }
    }
}
