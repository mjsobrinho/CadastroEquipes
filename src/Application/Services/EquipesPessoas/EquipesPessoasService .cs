using CadastroEquipes.src.Application.Comum;
using CadastroEquipes.src.Application.Interfaces.EquipesPessoas;
using CadastroEquipes.src.Domain.Entities.EquipesPessoas;
using CadastroEquipes.src.Domain.Interface.EquipesPessoas;
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;

namespace CadastroEquipes.src.Application.Services.EquipesPessoas
{
    public class EquipesPessoasService:IEquipesPessoasService
    {
        private readonly IEquipesPessoasRepository _equipesPessoasRepository;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;


        public EquipesPessoasService(IEquipesPessoasRepository equipesPessoasRepository,
            IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _equipesPessoasRepository = equipesPessoasRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public async Task<IEnumerable<EquipesPessoasDTO>> GetAllAsync()
        {
           var equipes = await _equipesPessoasRepository.GetAllAsync();

            return equipes.Select(p => new EquipesPessoasDTO
            {
                Id_Equipe = p.Id_Equipe,
                Cpf = p.Cpf
            }).ToList();
        }

        public async Task<EquipesPessoasDTO> GetByIdAsync(Guid id, string cpf)
        {
            var equipesPessoas = await _equipesPessoasRepository.GetByIdAsync(id, cpf);
            if (equipesPessoas == null) return null;

            return new EquipesPessoasDTO
            {
                Id_Equipe = equipesPessoas.Id_Equipe,
                Cpf = equipesPessoas.Cpf,
                idade = equipesPessoas.idade
            };
        }


        public async Task AddAsync(EquipesPessoasDTO equipePessoas)
        {
            var pessoaExistente = await _equipesPessoasRepository.GetByIdAsync(equipePessoas.Id_Equipe, equipePessoas.Cpf);

            // Verifica se já existe uma pessoa com o mesmo CPF
            if (pessoaExistente != null)
            {
                throw new ArgumentException("Já existe uma pessoa cadastrada com este CPF.");
            }

            var pessoa = await _pessoaFisicaRepository.GetByIdAsync(equipePessoas.Cpf);

            var dataatual = DateTime.Today;
            var idade = dataatual.Year - pessoa.Dt_Nasc.Year;


            // Validação do CPF
            if (!CpfValidator.ValidarCpf(equipePessoas.Cpf))
            {
                throw new ArgumentException("CPF Inválido.");
            }

            var entity = new EquipesPessoasDTO // Mudou para a entidade
            {
                
             Id_Equipe = equipePessoas.Id_Equipe,
             Cpf = equipePessoas.Cpf,
             idade = idade
            };

            await _equipesPessoasRepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Guid id, string cpf)
        {
            var equipesPessoas = await _equipesPessoasRepository.GetByIdAsync(id, cpf);
            if (equipesPessoas == null)
            {
                return false; // Retorna false se a pessoa física não for encontrada
            }

            await _equipesPessoasRepository.DeleteAsync(id, cpf); // Executa a exclusão
            return true; // Retorna true se a exclusão foi bem-sucedida
        }
    }
}
