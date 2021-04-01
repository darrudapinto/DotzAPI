using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;

namespace DotzAPI.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Task<Usuario> ObterPorIdAsync(AplicacaoDbContexto contexto, int id);
        Task<List<Usuario>> ObterTodosAsync(AplicacaoDbContexto contexto);
    }
}