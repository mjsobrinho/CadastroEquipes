using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;

namespace CadastroPessoaFisica.src.Application.Interfaces.PessoaFisica
{
    public interface IPessoaFisicaService
    {
        Task<IEnumerable<PessoaFisicaDTO>> GetAllAsync();
        Task<PessoaFisicaDTO> GetByIdAsync(string cpf); // Alinhado para usar 'string cpf'
        Task AddAsync(PessoaFisicaDTO pessoaFisica);
        Task<bool> UpdateAsync(PessoaFisicaDTO pessoaFisica);
        Task<bool> DeleteAsync(string cpf); // Corrigido para 'cpf'
    }
}
