﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectDeliv.Domain.Commands.ProdutoClasss;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Domain.Notifications;

namespace ProjectDeliv.Services.Api.Controllers.v1
{

    [Route("api/v1/[controller]")]
    public class ProdutoClassController : BaseController
    {
        private readonly IProdutoClassRepositorio _repositorio;

        public ProdutoClassController(IMediator mediator, INotificationHandler<DomainNotification> notifications, IProdutoClassRepositorio repositorio) : base(mediator, notifications)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return ResponseDefault(_repositorio.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            return ResponseDefault(_repositorio.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] ProdutoClassInsercaoCommand command)
        {
            Mediator.Send(command);
            return ResponseDefault();
        }

        [HttpPut]
        public IActionResult Inserir(Guid id, [FromBody] ProdutoClassInsercaoCommand command)
        {
            Mediator.Send(command);
            return ResponseDefault();
        }


        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Mediator.Send(new ProdutoClassDeletarCommand { Id = id });
            return ResponseDefault();
        }
    }
}
