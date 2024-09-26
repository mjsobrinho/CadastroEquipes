using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;
using Microsoft.EntityFrameworkCore;



namespace CadastroPessoaFisica.src.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<PessoaFisicaDTO> PessoasFisicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais podem ser feitas aqui
        }
    }
}
