using System;
using System.Linq;
using System.Threading.Tasks;
using DotzAPI.Database;

namespace DotzAPI.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class, new()
    {
        public IQueryable<TEntity> ObterTodos(AplicacaoDbContexto contexto)
        {
            try
            {
                return contexto.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível obter os usuários: {ex.Message}");
            }
        }

        public async Task<TEntity> AdicionarAsync(AplicacaoDbContexto contexto, TEntity entidade)
        {
            if (entidade == null)
                throw new ArgumentNullException($"{nameof(AdicionarAsync)} entidade não pode ser nula");

            try
            {
                await contexto.AddAsync(entidade);
                await contexto.SaveChangesAsync();

                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entidade)} não foi salva: {ex.Message}");
            }
        }

        public async Task<TEntity> AtualizarAsync(AplicacaoDbContexto contexto, TEntity entidade)
        {
            if (entidade == null)
                throw new ArgumentNullException($"{nameof(AdicionarAsync)} entidade não pode ser nula");

            try
            {
                contexto.Update(entidade);
                await contexto.SaveChangesAsync();

                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entidade)} não foi atualizada: {ex.Message}");
            }
        }
    }
}