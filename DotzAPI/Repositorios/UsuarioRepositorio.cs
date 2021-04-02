using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace DotzAPI.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AplicacaoDbContexto contexto) : base (contexto)
        {
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await ObterTodos().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await ObterTodos().ToListAsync();
        }
    }
}
