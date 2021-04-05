using System.Collections.Generic;

namespace DotzAPI.Modelos
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }

        public IList<CategoriaSubcategoria> CategoriaSubcategorias { get; set; }
    }
}