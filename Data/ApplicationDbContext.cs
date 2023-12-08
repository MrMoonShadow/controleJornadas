using controleJornadas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace controleJornadas.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<Usuario>(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Base> Bases { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Jornada> Jornadas { get; set; }
    }
}
