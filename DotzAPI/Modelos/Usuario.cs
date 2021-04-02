using System.Collections.Generic;
using DotzAPI.Enums;

namespace DotzAPI.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public Endereco Endereco { get; set; }
        public List<PontoDotz> PontosDotz { get; set; }
        public int QuantidadePontosDotzAcumulados { get; set; }

        public void AtualizarPontosDotzAcumulados(PontoDotz pontoDotz)
        {
            if (pontoDotz.TipoOperacao == TipoOperacao.Credito) { 
                QuantidadePontosDotzAcumulados = QuantidadePontosDotzAcumulados - pontoDotz.Quantidade;
                return;
            }

            QuantidadePontosDotzAcumulados = QuantidadePontosDotzAcumulados + pontoDotz.Quantidade;
        }
    }
}
