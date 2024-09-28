using CadastroEquipes.src.Domain.Entities.EquipesPessoas;

namespace CadastroEquipes.src.Application.Interfaces.EquipesPessoas
{
    public interface IEquipesPessoasService
    {
        Task<IEnumerable<EquipesPessoasRelatDTO>> GetAllAsync(); // Método para obter todas as equipes
        Task<EquipesPessoasDTO> GetByIdAsync(Guid id, string cpf); // Método para obter um equipe e pessoa
        Task AddAsync(EquipesPessoasDTO equipe); // Método para adicionar uma nova equipe
        Task<bool> DeleteAsync(Guid id, string cpf); // Método para deletar uma equipe pelo ID
    }
}
