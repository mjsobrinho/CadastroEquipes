using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;

namespace CadastroPessoaFisica.src.Domain.Interface.PessoaFisica
{
   public interface IPessoaFisicaRepository
    {
        Task<IEnumerable<PessoaFisicaDTO>> GetAllAsync();          // Retorna todas as pessoas físicas
        Task<PessoaFisicaDTO> GetByIdAsync(string cpf);               // Retorna uma pessoa física pelo cpf
        Task AddAsync(PessoaFisicaDTO pessoaFisica);              // Adiciona uma nova pessoa física
        Task UpdateAsync(PessoaFisicaDTO pessoaFisica);           // Atualiza uma pessoa física existente
        Task DeleteAsync(string cpf);                               // Remove uma pessoa física pelo ID
    }
}
