using CadastroPessoaFisica.src.Application.Interfaces.Pessoas;
using CadastroPessoaFisica.src.Domain.Entities.Pessoas;
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;
using CadastroEquipes.src.Application.Comum;
using System.Data.SqlClient;

namespace CadastroPessoaFisica.src.Application.Services.PessoaFisica
{
    public class PessoasService:IPessoasService
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoasService(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }


        public async Task<IEnumerable<PessoasDTO>> GetAllAsync()
        {
            var pessoasFisicas = await _pessoaFisicaRepository.GetAllAsync();

            return pessoasFisicas.Select(p => new PessoasDTO
            {
                Nome = p.Nome,
                Dt_Nasc = p.Dt_Nasc,
                Cpf = p.Cpf,
                Sexo = p.Sexo
            }).ToList();
        }

        public async Task<PessoasDTO> GetByIdAsync(string cpf)
        {
            var pessoaFisica = await _pessoaFisicaRepository.GetByIdAsync(cpf);
            if (pessoaFisica == null) return null;

            return new PessoasDTO
            {
                Nome = pessoaFisica.Nome,
                Dt_Nasc = pessoaFisica.Dt_Nasc,
                Cpf = pessoaFisica.Cpf,
                Sexo = pessoaFisica.Sexo
            };
        }

        public async Task AddAsync(PessoasDTO pessoaFisica)
        {
            var pessoaExistente = await _pessoaFisicaRepository.GetByIdAsync(pessoaFisica.Cpf);

            // Verifica se já existe uma pessoa com o mesmo CPF
            if (pessoaExistente != null)
            {
                throw new ArgumentException("Já existe uma pessoa cadastrada com este CPF.");
            }

            // Validação do valor do Sexo
            if (pessoaFisica.Sexo != "M" && pessoaFisica.Sexo != "F")
            {
                throw new ArgumentException("O valor do sexo deve ser 'M', 'F' ");
            }

            // Validação do CPF
            if (!CpfValidator.ValidarCpf(pessoaFisica.Cpf))
            {
                throw new ArgumentException("CPF Inválido.");
            }

            var entity = new PessoasDTO // Mudou para a entidade
            {
                Nome = pessoaFisica.Nome,
                Dt_Nasc = pessoaFisica.Dt_Nasc,
                Cpf = pessoaFisica.Cpf,
                Sexo = pessoaFisica.Sexo
            };

            await _pessoaFisicaRepository.AddAsync(entity);
        }


        public async Task<bool> UpdateAsync(PessoasDTO pessoaFisicaDto)
        {
            var pessoaFisica = await _pessoaFisicaRepository.GetByIdAsync(pessoaFisicaDto.Cpf);
            if (pessoaFisica == null) return false;

            // Atualiza os campos necessários
            pessoaFisica.Nome = pessoaFisicaDto.Nome;
            pessoaFisica.Dt_Nasc = pessoaFisicaDto.Dt_Nasc;
            pessoaFisica.Cpf = pessoaFisicaDto.Cpf;
            pessoaFisica.Sexo = pessoaFisicaDto.Sexo;

            await _pessoaFisicaRepository.UpdateAsync(pessoaFisica);
            return true;
        }

        public async Task<bool> DeleteAsync(string cpf)
        {
            try
            {

                var pessoaFisica = await _pessoaFisicaRepository.GetByIdAsync(cpf);
                if (pessoaFisica == null)
                {
                    return false; // Retorna false se a pessoa física não for encontrada
                }

                await _pessoaFisicaRepository.DeleteAsync(cpf); // Executa a exclusão
                return true; // Retorna true se a exclusão foi bem-sucedida
            }
            catch (Exception e)
            {
                string errorMessage = e.Message;
                string errorCode = "";

                if (e.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx)
                {
                    errorCode = sqlEx.Number.ToString(); // Obtém o código de erro SQL

                    if (errorCode == "547") {
                        errorMessage = "Pessoa já cadastrada em equipe, não permitida exclusão";
                    }
                   
                }

                else {
                    errorMessage = e.InnerException.Message; // Mensagem da InnerException
                }

                throw new ArgumentException(errorMessage);


                return false;
            }


         
        }

    }
}
