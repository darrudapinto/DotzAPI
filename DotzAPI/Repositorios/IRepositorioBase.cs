using System.Linq;
using System.Threading.Tasks;
using DotzAPI.Database;

namespace DotzAPI.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AdicionarAsync(AplicacaoDbContexto contexto, TEntity entidade);
        Task<TEntity> AtualizarAsync(AplicacaoDbContexto contexto, TEntity entidade);
        IQueryable<TEntity> ObterTodos(AplicacaoDbContexto contexto);
    }
}