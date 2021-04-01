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
    }
}
