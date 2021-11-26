using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Domain.Notifications;
using ProjectDeliv.Infra.Data.Contexts;

namespace ProjectDeliv.Services.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoClassController : ControllerBase
    {
        private readonly IProdutoClassRepositorio _repositorio;
        private readonly IMediator _mediator;
        private readonly ContextSQL _context;
        private readonly DomainNotificationHandler _notifications;
        public ProdutoClassController(IProdutoClassRepositorio repositorio, ContextSQL context, IMediator mediator, INotificationHandler<DomainNotification> notifications)
        {
            _repositorio = repositorio;
            _context = context;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_repositorio.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            return Ok(_repositorio.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] ProdutoClass entidade)
        {
            _repositorio.Inserir(entidade);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Inserir(Guid id, [FromBody] ProdutoClass entidade)
        {
            _repositorio.Atualizar(id, entidade);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _repositorio.Deletar(id);
            _context.SaveChanges();
            return Ok();
        }
    }
}
