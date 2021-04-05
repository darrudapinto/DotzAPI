using System.Collections.Generic;
using System.Linq;
using DotzAPI.Enums;

namespace DotzAPI.Modelos
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Endereco Endereco { get; set; }
        public ICollection<PontoDotz> PontosDotz { get; set; }

        public int QuantidadePontosDotzAcumulados { get; set; }

        public void AtualizarPontosDotzAcumulados()
        {
            var pontoDotz = PontosDotz.LastOrDefault();

            if (pontoDotz == null)
                return;

            if (pontoDotz.TipoOperacao == TipoOperacao.Credito) { 
                QuantidadePontosDotzAcumulados = QuantidadePontosDotzAcumulados + pontoDotz.Quantidade;
                return;
            }

            QuantidadePontosDotzAcumulados = QuantidadePontosDotzAcumulados - pontoDotz.Quantidade;
        }
    }
}
