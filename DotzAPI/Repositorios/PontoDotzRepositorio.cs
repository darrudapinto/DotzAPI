using DotzAPI.Database;
using DotzAPI.Modelos;

namespace DotzAPI.Repositorios
{
    public class PontoDotzRepositorio : RepositorioBase<PontoDotz>, IPontoDotzRepositorio
    {
        public PontoDotzRepositorio(AplicacaoDbContexto contexto) : base(contexto)
        {
        }
    }
}
