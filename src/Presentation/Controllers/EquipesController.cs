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

               

        // Endpoint para adicionar uma nova equipe
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EquipeDTO equipe)
        {
            if (equipe == null)
            {
                return BadRequest("Equipe não pode ser nula.");
            }

            await _equipesService.AddAsync(equipe);
            return CreatedAtAction(nameof(GetById), new { cpf = equipe.Id }, equipe);
        }


        // Método para obter por CPF
        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var equipe = await _equipesService.GetByIdAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

    }
}
