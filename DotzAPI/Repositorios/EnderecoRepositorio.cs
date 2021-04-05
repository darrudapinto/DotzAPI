using DotzAPI.Database;
using DotzAPI.Modelos;

namespace DotzAPI.Repositorios
{
    public class EnderecoRepositorio : RepositorioBase<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(AplicacaoDbContexto contexto) : base(contexto)
        {
        }
    }
}
