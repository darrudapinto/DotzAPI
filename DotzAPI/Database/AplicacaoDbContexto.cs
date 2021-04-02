using DotzAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace DotzAPI.Database
{
    public class AplicacaoDbContexto : DbContext
    {
        public AplicacaoDbContexto( DbContextOptions<AplicacaoDbContexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> SubCategorias { get; set; }
        public DbSet<PontoDotz> PontosDotz { get; set; }
    }
}
