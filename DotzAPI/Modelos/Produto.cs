namespace DotzAPI.Modelos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }
        public Subcategoria Subcategoria { get; set; }
        public int QuantidadePontosDotzParaResgate { get; set; }
    }
}
