using System;
using System.Linq;
using System.Threading.Tasks;
using DotzAPI.Database;
using Microsoft.AspNetCore.Mvc;

namespace DotzAPI.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class, new()
    {
        private readonly AplicacaoDbContexto Contexto;
        public RepositorioBase([FromServices] AplicacaoDbContexto contexto)
        {
            Contexto = contexto;
        }

        public IQueryable<TEntity> ObterTodos()
        {
            try
            {
                return Contexto.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível obter os usuários: {ex.Message}");
            }
        }

        public async Task<TEntity> AdicionarAsync(TEntity entidade)
        {
            if (entidade == null)
                throw new ArgumentNullException($"{nameof(AdicionarAsync)} entidade não pode ser nula");

            try
            {
                await Contexto.AddAsync(entidade);
                await Contexto.SaveChangesAsync();

                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entidade)} não foi salva: {ex.Message}");
            }
        }

        public async Task<TEntity> AtualizarAsync(TEntity entidade)
        {
            if (entidade == null)
                throw new ArgumentNullException($"{nameof(AdicionarAsync)} entidade não pode ser nula");

            try
            {
                Contexto.Update(entidade);
                await Contexto.SaveChangesAsync();

                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entidade)} não foi atualizada: {ex.Message}");
            }
        }
    }
}