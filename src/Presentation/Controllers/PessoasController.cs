using CadastroPessoaFisica.src.Application.Interfaces.Pessoas;
using CadastroPessoaFisica.src.Domain.Entities.Pessoas;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoaFisica.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasService _pessoaFisicaService;

        public PessoasController(IPessoasService pessoaFisicaService)
        {
            _pessoaFisicaService = pessoaFisicaService;
        }

        // 1. POST - Endpoint para adicionar uma nova pessoa física
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PessoasDTO pessoaFisica)
        {
            try
            {
                if (pessoaFisica == null)
                {
                    return BadRequest("Pessoa Física não pode ser nula.");
                }

                pessoaFisica.Cpf = pessoaFisica.Cpf.Replace(".", "").Replace("-", "");

                await _pessoaFisicaService.AddAsync(pessoaFisica);
                return CreatedAtAction(nameof(GetById), new { cpf = pessoaFisica.Cpf}, pessoaFisica);
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

        // 2. GET - Retorna todas as pessoas cadastradas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pessoaFisica = await _pessoaFisicaService.GetAllAsync();
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return Ok(pessoaFisica);
        }

        // 2. GET - Método para obter por CPF
        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetById(string cpf)
        {
            var pessoaFisica = await _pessoaFisicaService.GetByIdAsync(cpf.Replace(".", "").Replace("-", ""));
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return Ok(pessoaFisica);
        }

        // 3. PUT - Método para atualizar uma pessoa física
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PessoasDTO pessoaFisica)
        {
            if (pessoaFisica == null)
            {
                return BadRequest("Pessoa Física não pode ser nula.");
            }

            var resultado = await _pessoaFisicaService.UpdateAsync(pessoaFisica);
            if (!resultado)
            {
                return NotFound($"Pessoa Física com CPF {pessoaFisica.Cpf} não atualizado.");
            }

            return NoContent(); // Retorna 204 No Content ao atualizar com sucesso
        }

        // 4. DELETE - Método para deletar por CPF
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> Delete(string cpf)
        {
            try
            {
                var resultado = await _pessoaFisicaService.DeleteAsync(cpf);

                if (!resultado)
                {
                    return NotFound($"Pessoa Física com CPF {cpf} não encontrada.");
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
