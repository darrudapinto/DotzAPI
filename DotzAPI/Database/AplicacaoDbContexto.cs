using DotzAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace DotzAPI.Database
{
    public class AplicacaoDbContexto : DbContext
    {
        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> SubCategorias { get; set; }
        public DbSet<CategoriaSubcategoria> CategoriaSubcategorias { get; set; }
        public DbSet<PontoDotz> PontosDotz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaSubcategoria>().HasKey(cs => new {cs.CategoriaId, cs.SubcategoriaId});
            modelBuilder.Entity<PontoDotz>().HasOne<Usuario>(e => e.Usuario).WithMany(d => d.PontosDotz);
        }
    }
}
