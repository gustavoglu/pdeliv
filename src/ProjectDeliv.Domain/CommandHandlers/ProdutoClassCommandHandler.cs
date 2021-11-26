using MediatR;
using ProjectDeliv.Domain.Commands.ProdutoClasss;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Domain.Notifications;

namespace ProjectDeliv.Domain.CommandHandlers
{
    public class ProdutoClassCommandHandler : CommandHandlerBase, IRequestHandler<ProdutoClassInsercaoCommand>, IRequestHandler<ProdutoClassAtualizacaoCommand>, IRequestHandler<ProdutoClassDeletarCommand>
    {
        private readonly IProdutoClassRepositorio _repositorio;

        public ProdutoClassCommandHandler(INotificationHandler<DomainNotification> notifications, IMediator mediator, IUnitOfWork uow, IProdutoClassRepositorio repositorio) : base(notifications, mediator, uow)
        {
            _repositorio = repositorio;
        }

        public Task<Unit> Handle(ProdutoClassInsercaoCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;

            var entidade = new ProdutoClass(request.Descricao, request.ImagemUrl);
            _repositorio.Inserir(entidade);
            Commit();
            return Unit.Task;
        }

        public Task<Unit> Handle(ProdutoClassAtualizacaoCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;

            var entidade = new ProdutoClass(request.Descricao, request.ImagemUrl) { Id = request.Id };
            _repositorio.Atualizar(entidade.Id, entidade);
            Commit();
            return Unit.Task;
        }

        public Task<Unit> Handle(ProdutoClassDeletarCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;

            _repositorio.Deletar(request.Id);
            Commit();
            return Unit.Task;
        }
    }
}
