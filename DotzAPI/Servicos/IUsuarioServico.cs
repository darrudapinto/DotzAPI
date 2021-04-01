using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;

namespace DotzAPI.Servicos
{
    public interface IUsuarioServico
    {
        Task<List<Usuario>> ObterTodosAsync(AplicacaoDbContexto contexto);
        Task<Usuario> ObterPorIdAsync(AplicacaoDbContexto contexto, int id);
        Task<Usuario> AdicionarAsync(AplicacaoDbContexto contexto, Usuario usuario);
    }
}