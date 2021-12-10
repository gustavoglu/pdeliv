using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectDeliv.Domain.EventSourcing;
using ProjectDeliv.Domain.Notifications;

namespace ProjectDeliv.Services.Api.Controllers.v1
{

    [Route("api/v1/[controller]")]
    public class EventStoreController : BaseController
    {
        private readonly IEventStoreRepositorio _repositorio;

        public EventStoreController(IMediator mediator, INotificationHandler<DomainNotification> notifications, IEventStoreRepositorio repositorio) : base(mediator, notifications)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult ObterPorAggregateId(Guid aggregateId)
        {
            return ResponseDefault(_repositorio.GetByAggregateId(aggregateId));
        }

    }
}
