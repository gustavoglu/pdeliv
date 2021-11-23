using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDeliv.Domain.Entidades
{
    public class Produto : EntidadeBase
    {
        public Produto()
        {

        }

        public int Codigo { get; set; }
        public string Descricao { get; set; }



        public Guid ProdutoGrupoId { get; set; }
        public ProdutoGrupo ProdutoGrupo { get; set; }
    }
}
