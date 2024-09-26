using CadastroEquipes.src.Domain.Entities.Equipes;


namespace CadastroEquipes.src.Application.Interfaces.Equipes
{

    public interface IEquipesService
    {
        Task<IEnumerable<EquipeDTO>> GetAllAsync(); // Método para obter todas as equipes
        Task<EquipeDTO> GetByIdAsync(Guid id); // Método para obter uma equipe pelo ID
        Task AddAsync(EquipeDTO equipe); // Método para adicionar uma nova equipe
        Task<bool> UpdateAsync(EquipeDTO equipe); // Método para atualizar uma equipe existente
        Task<bool> DeleteAsync(Guid id); // Método para deletar uma equipe pelo ID
    }
}
