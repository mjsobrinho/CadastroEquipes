using CadastroEquipes.src.Domain.Entities.Equipes;
using CadastroEquipes.src.Domain.Entities.EquipesPessoas;
using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoaFisica.src.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<PessoasDTO> PessoasFisicas { get; set; }
        public DbSet<EquipeDTO> Equipes { get; set; }
        public DbSet<EquipePessoasDTO> EquipesPessoas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais podem ser feitas aqui
        }
    }
}
