using System.Collections.Generic;

namespace DotzAPI.Modelos
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadePontosDotzParaResgate { get; set; }        
    }
}
