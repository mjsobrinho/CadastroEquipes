using CadastroPessoaFisica.src.Application.Interfaces.PessoaFisica;
using CadastroPessoaFisica.src.Domain.Entities.PessoaFisica;
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;

namespace CadastroPessoaFisica.src.Application.Services.PessoaFisica
{
    public class PessoaFisicaService:IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }


        public async Task<IEnumerable<PessoaFisicaDTO>> GetAllAsync()
        {
            var pessoasFisicas = await _pessoaFisicaRepository.GetAllAsync();

            return pessoasFisicas.Select(p => new PessoaFisicaDTO
            {
                Nome = p.Nome,
                Dt_Nasc = p.Dt_Nasc,
                Cpf = p.Cpf,
                Sexo = p.Sexo
            }).ToList();
        }

        public async Task<PessoaFisicaDTO> GetByIdAsync(string cpf)
        {
            var pessoaFisica = await _pessoaFisicaRepository.GetByIdAsync(cpf);
            if (pessoaFisica == null) return null;

            return new PessoaFisicaDTO
            {
                Nome = pessoaFisica.Nome,
                Dt_Nasc = pessoaFisica.Dt_Nasc,
                Cpf = pessoaFisica.Cpf,
                Sexo = pessoaFisica.Sexo
            };
        }

        public async Task AddAsync(PessoaFisicaDTO pessoaFisica)
        {
            var entity = new PessoaFisicaDTO // Mudou para a entidade
            {
                Nome = pessoaFisica.Nome,
                Dt_Nasc = pessoaFisica.Dt_Nasc,
                Cpf = pessoaFisica.Cpf,
                Sexo = pessoaFisica.Sexo
            };

            await _pessoaFisicaRepository.AddAsync(entity);
        }


        public async Task<bool> UpdateAsync(PessoaFisicaDTO pessoaFisicaDto)
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
            var pessoaFisica = await _pessoaFisicaRepository.GetByIdAsync(cpf);
            if (pessoaFisica == null)
            {
                return false; // Retorna false se a pessoa física não for encontrada
            }

            await _pessoaFisicaRepository.DeleteAsync(cpf); // Executa a exclusão
            return true; // Retorna true se a exclusão foi bem-sucedida
        }
        


    }
}
