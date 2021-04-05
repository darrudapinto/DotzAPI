using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Modelos;

namespace DotzAPI.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Task<Usuario> ObterPorIdAsync(int id);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<List<Usuario>> ObterTodosAsync();
    }
}