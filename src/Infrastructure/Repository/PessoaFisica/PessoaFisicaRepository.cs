using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoaFisica.src.Infrastructure.Repository.PessoaFisica
{
    public class PessoaFisicaRepository: IPessoaFisicaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaFisicaRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<PessoaFisicaDTO>> GetAllAsync()
        {
            return await _context.PessoasFisicas.ToListAsync(); 
        }


        public async Task<PessoaFisicaDTO> GetByIdAsync(string cpf)
        {
            return await _context.PessoasFisicas.FindAsync(cpf);
        }

        public async Task AddAsync(PessoaFisicaDTO pessoaFisica)
        {
            await _context.PessoasFisicas.AddAsync(pessoaFisica);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PessoaFisicaDTO pessoaFisica)
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
