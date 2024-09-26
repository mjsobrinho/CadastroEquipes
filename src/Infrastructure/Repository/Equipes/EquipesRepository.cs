using CadastroEquipes.src.Domain.Entities.Equipes;
using CadastroEquipes.src.Domain.Interface.Equipes;
using CadastroPessoaFisica.src.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CadastroEquipes.src.Infrastructure.Repository.Equipes
{
    public class EquipesRepository : IEquipesRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EquipeDTO>> GetAllAsync()
        {
            return await _context.Equipes.ToListAsync();
        }

        public async Task<EquipeDTO> GetByIdAsync(Guid id)
        {
            return await _context.Equipes.FindAsync(id);
        }


        public async Task AddAsync(EquipeDTO equipe)
        {
            await _context.Equipes.AddAsync(equipe);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(EquipeDTO equipe)
        {
            _context.Equipes.Update(equipe);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe != null)
            {
                _context.Equipes.Remove(equipe);
                await _context.SaveChangesAsync();
            }
        }

    }
}
