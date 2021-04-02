using System.Linq;
using System.Threading.Tasks;
using DotzAPI.Database;

namespace DotzAPI.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AdicionarAsync(TEntity entidade);
        Task<TEntity> AtualizarAsync(TEntity entidade);
        IQueryable<TEntity> ObterTodos();
    }
}