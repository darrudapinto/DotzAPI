using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;

namespace DotzAPI.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Task<Usuario> ObterPorIdAsync(int id);
        Task<List<Usuario>> ObterTodosAsync();
    }
}