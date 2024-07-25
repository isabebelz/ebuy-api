using ebuy.Application.UseCases.User.Commands.CreateUser;
using ebuy.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ebuy.WebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(INotificationHandler<DomainNotification> notifications,
                              INotificationHandler<DomainSuccesNotification> succesNotification,
                              IMediator mediator)
        : base (notifications, succesNotification, mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            var command = new CreateUserCommand(request);
            var result = await _mediator.Send(command);
            return Response(result);
        }
    }
}
