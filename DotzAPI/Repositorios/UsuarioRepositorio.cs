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
            return await ObterTodosComEagerLoad(u => u.Endereco, u => u.PontosDotz).FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await ObterTodosComEagerLoad(u => u.Endereco, u => u.PontosDotz).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await ObterTodosComEagerLoad(u => u.Endereco, u => u.PontosDotz).ToListAsync();
        }
    }
}
