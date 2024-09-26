﻿using CadastroPessoaFisica.src.Application.Interfaces.PessoaFisica;
using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CadastroPessoaFisica.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService)
        {
            _pessoaFisicaService = pessoaFisicaService;
        }

        // Endpoint para adicionar uma nova pessoa física
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PessoaFisicaDTO pessoaFisica)
        {
            try
            {
                if (pessoaFisica == null)
                {
                    return BadRequest("Pessoa Física não pode ser nula.");
                }

                await _pessoaFisicaService.AddAsync(pessoaFisica);
                return CreatedAtAction(nameof(GetById), new { cpf = pessoaFisica.Cpf }, pessoaFisica);
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

        // Método para atualizar uma pessoa física
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PessoaFisicaDTO pessoaFisica)
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

        // Método para obter por CPF
        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetById(string cpf)
        {
            var pessoaFisica = await _pessoaFisicaService.GetByIdAsync(cpf);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return Ok(pessoaFisica);
        }

        //Retorna todos as pessoas cadastradas
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var pessoaFisica = await _pessoaFisicaService.GetAllAsync();
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return Ok(pessoaFisica);
        }

        // Método para deletar por CPF
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> Delete(string cpf)
        {
            // Chama o serviço para tentar excluir a pessoa física
            var resultado = await _pessoaFisicaService.DeleteAsync(cpf);

            // Verifica se a pessoa física foi encontrada e excluída
            if (!resultado)
            {
                return NotFound($"Pessoa Física com CPF {cpf} não encontrada.");
            }

            // Retorna uma resposta 204 No Content ao excluir com sucesso
            return NoContent();
        }

    }
}
