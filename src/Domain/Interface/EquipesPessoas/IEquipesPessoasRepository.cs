using CadastroEquipes.src.Domain.Entities.EquipesPessoas;

namespace CadastroEquipes.src.Domain.Interface.EquipesPessoas
{
    public interface IEquipesPessoasRepository
    {
        Task<IEnumerable<EquipesPessoasDTO>> GetAllAsync(); // Método para obter todas as associações de equipes e pessoas
        Task<EquipesPessoasDTO> GetByIdAsync(Guid idEquipe, string cpf); // Método para obter uma associação pelo ID da equipe e CPF
        Task AddAsync(EquipesPessoasDTO equipePessoa); // Método para adicionar uma nova associação
        Task DeleteAsync(Guid idEquipe, string cpf); // Método para deletar uma associação pelo ID da equipe e CPF
    }
}
