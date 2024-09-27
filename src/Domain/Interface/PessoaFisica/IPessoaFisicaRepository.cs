using CadastroPessoaFisica.src.Domain.Entities.Pessoas;

namespace CadastroPessoaFisica.src.Domain.Interface.PessoaFisica
{
   public interface IPessoaFisicaRepository
    {
        Task<IEnumerable<PessoasDTO>> GetAllAsync();          // Retorna todas as pessoas físicas
        Task<PessoasDTO> GetByIdAsync(string cpf);               // Retorna uma pessoa física pelo cpf
        Task AddAsync(PessoasDTO pessoaFisica);              // Adiciona uma nova pessoa física
        Task UpdateAsync(PessoasDTO pessoaFisica);           // Atualiza uma pessoa física existente
        Task DeleteAsync(string cpf);                               // Remove uma pessoa física pelo ID
    }
}
