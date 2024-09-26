using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;

namespace CadastroPessoaFisica.src.Application.Interfaces.PessoaFisica
{
    public interface IPessoasService
    {
        Task<IEnumerable<PessoasDTO>> GetAllAsync();
        Task<PessoasDTO> GetByIdAsync(string cpf); // Alinhado para usar 'string cpf'
        Task AddAsync(PessoasDTO pessoaFisica);
        Task<bool> UpdateAsync(PessoasDTO pessoaFisica);
        Task<bool> DeleteAsync(string cpf); // Corrigido para 'cpf'
    }
}
