using CadastroPessoaFisica.src.Domain.Entities.Pessoas;
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoaFisica.src.Infrastructure.Repository.Pessoas
{
    public class PessoasRepository: IPessoaFisicaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoasRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<PessoasDTO>> GetAllAsync()
        {
            return await _context.PessoasFisicas.ToListAsync(); 
        }


        public async Task<PessoasDTO> GetByIdAsync(string cpf)
        {
            return await _context.PessoasFisicas.FindAsync(cpf);
        }

        public async Task AddAsync(PessoasDTO pessoaFisica)
        {
            await _context.PessoasFisicas.AddAsync(pessoaFisica);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PessoasDTO pessoaFisica)
        {
            _context.PessoasFisicas.Update(pessoaFisica);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string cpf)
        {
            var pessoaFisica = await _context.PessoasFisicas.FindAsync(cpf);
            if (pessoaFisica != null)
            {
                _context.PessoasFisicas.Remove(pessoaFisica);
                await _context.SaveChangesAsync();
            }
        }

    }
}
