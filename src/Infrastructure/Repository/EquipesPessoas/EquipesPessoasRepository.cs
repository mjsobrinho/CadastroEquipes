using CadastroEquipes.src.Domain.Entities.EquipesPessoas;
using CadastroEquipes.src.Domain.Interface.EquipesPessoas;
using CadastroPessoaFisica.src.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CadastroEquipes.src.Infrastructure.Repository.EquipesPessoas
{
    public class EquipesPessoasRepository: IEquipesPessoasRepository
    {
        private readonly ApplicationDbContext _context;
        public EquipesPessoasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EquipesPessoasDTO>> GetAllAsync()
        {
            return await _context.EquipesPessoas.ToListAsync();
        }

        public async Task<EquipesPessoasDTO> GetByIdAsync(Guid idEquipe, string cpf)
        {
            return await _context.EquipesPessoas.FindAsync(idEquipe, cpf);
        }

        public async Task AddAsync(EquipesPessoasDTO equipePessoas)
        {
            await _context.EquipesPessoas.AddAsync(equipePessoas);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid idEquipe, string cpf)
        {
            var equipesPessoas = await _context.EquipesPessoas.FindAsync(idEquipe, cpf);
            if (equipesPessoas != null)
            {
                _context.EquipesPessoas.Remove(equipesPessoas);
                await _context.SaveChangesAsync();
            }
        }

    }
}
