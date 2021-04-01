using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;

namespace DotzAPI.Servicos
{
    public interface IEnderecoServico
    {
        Task<Endereco> AdicionarAsync(AplicacaoDbContexto contexto, Endereco endereco);
    }
}
