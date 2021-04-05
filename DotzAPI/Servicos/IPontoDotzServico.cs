using System.Threading.Tasks;
using DotzAPI.Modelos;

namespace DotzAPI.Servicos
{
    public interface IPontoDotzServico
    {
        Task<PontoDotz> AdicionarAsync(PontoDotz pontoDotz);
    }
}
