using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace DotzAPI.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public async Task<Usuario> ObterPorIdAsync(AplicacaoDbContexto contexto, int id)
        {
            return await ObterTodos(contexto).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> ObterTodosAsync(AplicacaoDbContexto contexto)
        {
            return await ObterTodos(contexto).ToListAsync();
        }
    }
}
