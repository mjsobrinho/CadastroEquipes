using CadastroEquipes.src.Domain.Entities.Equipes;
using CadastroEquipes.src.Domain.Entities.EquipesPessoas;
using CadastroPessoaFisica.src.Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoaFisica.src.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<PessoasDTO> PessoasFisicas { get; set; }
        public DbSet<EquipeDTO> Equipes { get; set; }
        public DbSet<EquipesPessoasDTO> EquipesPessoas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais podem ser feitas aqui
        }
    }
}
