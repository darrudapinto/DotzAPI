using System;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using DotzAPI.Repositorios;

namespace DotzAPI.Servicos
{
    public class EnderecoServico : IEnderecoServico
    {
        private readonly IEnderecoRepositorio Repositorio;

        public EnderecoServico(IEnderecoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public async Task<Endereco> AdicionarAsync(AplicacaoDbContexto contexto, Endereco endereco)
        {
            return await Repositorio.AdicionarAsync(contexto, endereco);
        }
    }
}
