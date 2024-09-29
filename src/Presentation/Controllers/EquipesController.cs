using CadastroEquipes.src.Application.Interfaces.Equipes;
using CadastroEquipes.src.Domain.Entities.Equipes;
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

      

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EquipeDTO equipe)
        {
            try
            {
                if (equipe == null)
                {
                    return BadRequest("Equipe não pode ser nula.");
                }

                await _equipesService.AddAsync(equipe);
                return CreatedAtAction(nameof(GetById), new { id = equipe.id_Equipe }, equipe);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Outra captura genérica para erros inesperados
                return StatusCode(500, new { Message = "Ocorreu um erro no servidor." });
            }

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



        // Método para atualizar uma pessoa física
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EquipeDTO equipe)
        {

            try
            {
                var resultado = await _equipesService.UpdateAsync(equipe);
                if (!resultado)
                {
                    return NotFound($"Equipe não atualizada {equipe.id_Equipe} não atualizado.");
                }

                return NoContent(); // Retorna 204 No Content ao atualizar com sucesso
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Outra captura genérica para erros inesperados
                return StatusCode(500, new { Message = "Ocorreu um erro no servidor." });
            }

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
