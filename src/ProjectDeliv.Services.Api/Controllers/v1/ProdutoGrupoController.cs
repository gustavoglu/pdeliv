using Microsoft.AspNetCore.Mvc;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Infra.Data.Contexts;

namespace ProjectDeliv.Services.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoGrupoController : ControllerBase
    {
        private readonly IProdutoGrupoRepositorio _repositorio;
        private readonly ContextSQL _context;
        public ProdutoGrupoController(IProdutoGrupoRepositorio repositorio, ContextSQL context)
        {
            _repositorio = repositorio;
            _context = context;
        }

        [HttpGet]
        public IActionResult ObterTodos(int pagina, int limite)
        {
            return Ok(_repositorio.ObterTodos(pagina, limite));
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            return Ok(_repositorio.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] ProdutoGrupo entidade)
        {
            _repositorio.Inserir(entidade);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Inserir(Guid id, [FromBody] ProdutoGrupo entidade)
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
