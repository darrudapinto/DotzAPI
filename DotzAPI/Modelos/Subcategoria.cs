using System.Collections.Generic;

namespace DotzAPI.Modelos
{
    public class Subcategoria
    {
        public int SubcategoriaId { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos{ get; set; }
        public IList<CategoriaSubcategoria> CategoriaSubcategorias { get; set; }
    }
}