using CadastroEquipes.src.Application.Comum;
using CadastroEquipes.src.Application.Interfaces.EquipesPessoas;
using CadastroEquipes.src.Domain.Entities.EquipesPessoas;
using CadastroEquipes.src.Domain.Interface.Equipes;
using CadastroEquipes.src.Domain.Interface.EquipesPessoas;
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;

namespace CadastroEquipes.src.Application.Services.EquipesPessoas
{
    public class EquipesPessoasService:IEquipesPessoasService
    {
        private readonly IEquipesPessoasRepository _equipesPessoasRepository;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IEquipesRepository _equipesRepository;

        public EquipesPessoasService(
            IEquipesPessoasRepository equipesPessoasRepository,
            IEquipesRepository equipesRepository,
            IPessoaFisicaRepository pessoaFisicaRepository
            )
        {
            _equipesPessoasRepository = equipesPessoasRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _equipesRepository = equipesRepository;
        }

        public async Task<IEnumerable<EquipesPessoasRelatDTO>> GetAllAsync()
        {
           var equipes = await _equipesPessoasRepository.GetAllAsync();

            return equipes.Select(p => new EquipesPessoasRelatDTO
            {
                id_Equipe = p.id_Equipe,
                Cpf = p.Cpf,
                nome = p.nome,
                nm_equipe = p.nm_equipe,
                idade  = p.idade,
                sexo = p.sexo,

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

            // Validação do CPF
            if (!CpfValidator.ValidarCpf(equipePessoas.Cpf))
            {
                throw new ArgumentException("CPF Inválido.");
            }

            var pessoaExistente = await _equipesPessoasRepository.GetByIdAsync(equipePessoas.Id_Equipe, equipePessoas.Cpf);

            // Verifica se já existe uma pessoa com o mesmo CPF
            if (pessoaExistente != null)
            {
                throw new ArgumentException("Pessoa já cadastrada na equipe.");
            }

            var pessoa = await _pessoaFisicaRepository.GetByIdAsync(equipePessoas.Cpf.Replace("-","").Replace(".",""));

            var equipe = await _equipesRepository.GetByIdAsync(equipePessoas.Id_Equipe);


            var dataatual = DateTime.Today;
            var idade = dataatual.Year - pessoa.Dt_Nasc.Year;

            //Valida a idade pra entrar na equipe
            if (equipe.Idad_Mini > idade)
                throw new ArgumentException("Idade não permitida pra esta equipe.");


            if (equipe.Sexo != "A" && equipe.Sexo != pessoa.Sexo)
            {
                if (pessoa.Sexo == "M")
                     throw new ArgumentException("Equipe não aceita sexo masculino.");

                if (pessoa.Sexo == "F")
                    throw new ArgumentException("Equipe não aceita sexo feminino.");

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
