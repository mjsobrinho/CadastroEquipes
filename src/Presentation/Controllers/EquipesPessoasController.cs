using CadastroEquipes.src.Application.Interfaces.EquipesPessoas;
using CadastroEquipes.src.Domain.Entities.EquipesPessoas;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEquipes.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipesPessoasController: ControllerBase
    {
        private readonly IEquipesPessoasService _equipesPessoasService;

        public EquipesPessoasController(IEquipesPessoasService equipePessoasService)
        {
            _equipesPessoasService = equipePessoasService;
        }

        // Endpoint para adicionar uma nova pessoa física
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EquipesPessoasDTO equipesPessoas)
        {
            try
            {
                if (equipesPessoas == null)
                {
                    return BadRequest("Equipe não pode ser nula.");
                }

                await _equipesPessoasService.AddAsync(equipesPessoas);
                return CreatedAtAction(nameof(GetById), new { id = equipesPessoas.Id_Equipe, cpf = equipesPessoas.Cpf }, equipesPessoas);
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

        // Método para obter a equipe
        [HttpGet("{id}/{cpf}")]
        public async Task<IActionResult> GetById(Guid id, string cpf)
        {
            var equipePessoas = await _equipesPessoasService.GetByIdAsync(id, cpf)
                ;
            if (equipePessoas == null)
            {
                return NotFound();
            }

            return Ok(equipePessoas);
        }

        //Retorna todos as pessoas cadastradas
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var equipe = await _equipesPessoasService.GetAllAsync();
            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

        // 4. DELETE - Método para deletar por CPF/id_equipe
        [HttpDelete("{Id_Equipe}/{cpf}")]
        public async Task<IActionResult> Delete(Guid Id_Equipe, string cpf)
        {
            try
            {
                var resultado = await _equipesPessoasService.DeleteAsync(Id_Equipe, cpf);

                if (!resultado)
                {
                    return NotFound($"Registro não encontrado {cpf} não encontrada.");
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ocorreu um erro no servidor." });
            }
        }


    }
}
