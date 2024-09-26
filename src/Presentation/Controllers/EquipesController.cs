using CadastroEquipes.src.Application.Interfaces.Equipes;
using CadastroEquipes.src.Domain.Entities.Equipes;
using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEquipes.src.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EquipesController: ControllerBase
    {
        private readonly IEquipesService _equipesService;

        public EquipesController(IEquipesService equipesService)
        {
            _equipesService = equipesService;
        }

               

        // Endpoint para adicionar uma nova equipe
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EquipeDTO equipe)
        {
            if (equipe == null)
            {
                return BadRequest("Equipe não pode ser nula.");
            }

            await _equipesService.AddAsync(equipe);
            return CreatedAtAction(nameof(GetById), new { id = equipe.Id }, equipe);
        }


        // Método para atualizar uma pessoa física
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EquipeDTO equipe)
        {
            if (equipe == null)
            {
                return BadRequest("Equipe não pode ser nula.");
            }

            var resultado = await _equipesService.UpdateAsync(equipe);
            if (!resultado)
            {
                return NotFound($"Equipe não atualizada {equipe.Id} não atualizado.");
            }

            return NoContent(); // Retorna 204 No Content ao atualizar com sucesso
        }

        // Método para obter por CPF
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var equipe = await _equipesService.GetByIdAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

        //Retorna todos as pessoas cadastradas
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var equipe = await _equipesService.GetAllAsync();
            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }


        // Método para deletar por CPF
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Chama o serviço para tentar excluir a pessoa física
            var resultado = await _equipesService.DeleteAsync(id);

            // Verifica se a pessoa física foi encontrada e excluída
            if (!resultado)
            {
                return NotFound($"Equipe com {id} não encontrada.");
            }

            // Retorna uma resposta 204 No Content ao excluir com sucesso
            return NoContent();
        }

    }
}
