using AutoMapper;
using ProjectDeliv.Domain.Commands.ProdutoClasss;
using ProjectDeliv.Domain.Entidades;

namespace ProjectDeliv.Domain.MapProfiles
{
    public class CommandParaEntidade : Profile
    {
        public CommandParaEntidade()
        {
            CreateMap<ProdutoClassInsercaoCommand, ProdutoClass>();
            CreateMap<ProdutoClassAtualizacaoCommand, ProdutoClass>();
        }
    }
}
