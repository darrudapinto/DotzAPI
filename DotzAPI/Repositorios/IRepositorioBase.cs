using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotzAPI.Database;

namespace DotzAPI.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AdicionarAsync(TEntity entidade);
        Task<TEntity> AtualizarAsync(TEntity entidade);
        IQueryable<TEntity> ObterTodos();
        IQueryable<TEntity> ObterTodosComEagerLoad(params Expression<Func<TEntity, object>>[] propriedadesNevageacao);        
    }
}