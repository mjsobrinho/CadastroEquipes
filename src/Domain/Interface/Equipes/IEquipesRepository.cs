using CadastroEquipes.src.Domain.Entities.Equipes;

namespace CadastroEquipes.src.Domain.Interface.Equipes
{
    public interface IEquipesRepository
    {
        Task<IEnumerable<EquipeDTO>> GetAllAsync();          // Retorna todas as pessoas físicas
        Task<EquipeDTO> GetByIdAsync(Guid id);               // Retorna uma pessoa física pelo id da equipe
        Task AddAsync(EquipeDTO equipe);                    // Adiciona uma nova pessoa física
        Task UpdateAsync(EquipeDTO equipe);                 // Atualiza uma pessoa física existente
        Task DeleteAsync(Guid id);                           // Remove uma pessoa física pelo ID
    }
}
