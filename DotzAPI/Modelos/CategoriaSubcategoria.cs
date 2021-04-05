namespace DotzAPI.Modelos
{
    public class CategoriaSubcategoria
    {
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int SubcategoriaId { get; set; }
        public Subcategoria Subcategoria { get; set; }
    }
}