using AutoMapper;
using MediatR;
using ProjectDeliv.Domain.Commands.ProdutoClasss;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.EventSourcing;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Domain.Notifications;

namespace ProjectDeliv.Domain.CommandHandlers
{
    public class ProdutoClassCommandHandler : CommandHandlerBase, IRequestHandler<ProdutoClassInsercaoCommand>, IRequestHandler<ProdutoClassAtualizacaoCommand>, IRequestHandler<ProdutoClassDeletarCommand>
    {
        private readonly IProdutoClassRepositorio _repositorio;

        public ProdutoClassCommandHandler(INotificationHandler<DomainNotification> notifications, IMediator mediator, 
            IUnitOfWork uow, IProdutoClassRepositorio repositorio,IMapper mapper, IEventStoreRepositorio eventStoreRepositorio) : base(notifications, mediator, uow, mapper, eventStoreRepositorio)
        {
            _repositorio = repositorio;
        }

        public Task<Unit> Handle(ProdutoClassInsercaoCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;

            var entidade = Mapper.Map<ProdutoClass>(request);
            _repositorio.Inserir(entidade);

            if (HasNotification()) return Unit.Task;

            EventStoreRepositorio.Save(new EventStore(entidade.Id, request.GetType().Name, entidade));

            Commit();
            return Unit.Task;
        }

        public Task<Unit> Handle(ProdutoClassAtualizacaoCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;

            var entidade = Mapper.Map<ProdutoClass>(request);
            _repositorio.Atualizar(entidade.Id, entidade);

            if (HasNotification()) return Unit.Task;

            EventStoreRepositorio.Save(new EventStore(entidade.Id, request.GetType().Name, entidade));

            Commit();
            return Unit.Task;
        }

        public Task<Unit> Handle(ProdutoClassDeletarCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;

            _repositorio.Deletar(request.Id);

            if (HasNotification()) return Unit.Task;

            EventStoreRepositorio.Save(new EventStore(request.Id, request.GetType().Name));

            Commit();
            return Unit.Task;
        }
    }
}
