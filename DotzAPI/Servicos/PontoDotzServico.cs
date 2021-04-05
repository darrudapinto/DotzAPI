using System.Threading.Tasks;
using DotzAPI.Modelos;
using DotzAPI.Repositorios;

namespace DotzAPI.Servicos
{
    public class PontoDotzServico : IPontoDotzServico
    {
        private readonly IPontoDotzRepositorio Repositorio;

        public PontoDotzServico(IPontoDotzRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public async Task<PontoDotz> AdicionarAsync(PontoDotz pontoDotz)
        {
            return await Repositorio.AdicionarAsync(pontoDotz);
        }
    }
}
