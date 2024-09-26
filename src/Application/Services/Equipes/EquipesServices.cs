using CadastroEquipes.src.Application.Interfaces.Equipes;
using CadastroEquipes.src.Domain.Entities.Equipes;
using CadastroEquipes.src.Domain.Interface.Equipes;

namespace CadastroEquipes.src.Application.Services.Equipe

{
    public class EquipesServices:IEquipesService
    {

        private readonly IEquipesRepository _equipeRepository;

        public EquipesServices(IEquipesRepository pessoaFisicaRepository)
        {
            _equipeRepository = pessoaFisicaRepository;
        }

        public async Task<IEnumerable<EquipeDTO>> GetAllAsync()
        {
            var equipes = await _equipeRepository.GetAllAsync();

            return equipes.Select(p => new EquipeDTO
            {
                Id = p.Id,
                Nm_Equipe = p.Nm_Equipe,
                Idad_Mini = p.Idad_Mini,
                Sexo = p.Sexo
                
            }).ToList();
        }

        public async Task<EquipeDTO> GetByIdAsync(Guid id)
        {
            var equipe = await _equipeRepository.GetByIdAsync(id);
            if (equipe == null) return null;

            return new EquipeDTO
            {
                Id =equipe.Id,
                Nm_Equipe = equipe.Nm_Equipe,
                Idad_Mini = equipe.Idad_Mini,
                Sexo = equipe.Sexo
            };
        }

        public async Task AddAsync(EquipeDTO equipe)
        {
            var entity = new EquipeDTO
            {
                Id= Guid.NewGuid(),
                Nm_Equipe = equipe.Nm_Equipe,
                Idad_Mini = equipe.Idad_Mini,
                Sexo   = equipe.Sexo
            };

            await _equipeRepository.AddAsync(entity);
        }
       

        public async Task<bool> UpdateAsync(EquipeDTO equipeDTO)
        {
            var equipe = await _equipeRepository.GetByIdAsync(equipeDTO.Id);
            if (equipe == null) return false;

            // Atualiza os campos necessários
            equipe.Nm_Equipe = equipeDTO.Nm_Equipe;
            equipe.Idad_Mini = equipeDTO.Idad_Mini;
            equipe.Sexo = equipeDTO.Sexo;

            await _equipeRepository.UpdateAsync(equipe);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var equipe = await _equipeRepository.GetByIdAsync(id);
            if (equipe == null)
            {
                return false; // Retorna false se a pessoa física não for encontrada
            }

            await _equipeRepository.DeleteAsync(id); // Executa a exclusão
            return true; // Retorna true se a exclusão foi bem-sucedida
        }



    }
}
