using CadastroEquipes.src.Domain.Entities.EquipesPessoas;
using CadastroEquipes.src.Domain.Interface.EquipesPessoas;
using CadastroPessoaFisica.src.Infrastructure;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CadastroEquipes.src.Infrastructure.Repository.EquipesPessoas
{
    public class EquipesPessoasRepository : IEquipesPessoasRepository
    {
        private readonly ApplicationDbContext _context;
        public EquipesPessoasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EquipesPessoasRelatDTO>> GetAllAsync()
        {

            string sqlGet = @"
            SELECT
                c.id_Equipe AS id_Equipe, 
                b.cpf AS cpf,
                b.nome AS nome,
                c.nm_equipe AS nm_equipe,
                b.sexo AS sexo,
                a.idade AS idade
            FROM
                 tb_equipes_pessoas a (nolock)
            INNER JOIN 
                 tb_pessoas b (nolock) ON a.cpf = b.cpf
            INNER JOIN 
                tb_equipes c (nolock) ON c.id_Equipe = a.id_Equipe ";

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync(); // Abre a conexão com o banco de dados

                // Executa a consulta e retorna a lista de resultados
                var results = await connection.QueryAsync<EquipesPessoasRelatDTO>(sqlGet);

                return results; // Retorna a lista de resultados
            }

        }

        public async Task<EquipesPessoasDTO> GetByIdAsync(Guid idEquipe, string cpf)
        {
            return await _context.EquipesPessoas.FindAsync(idEquipe, cpf);
        }

        public async Task AddAsync(EquipesPessoasDTO equipePessoas)
        {
            await _context.EquipesPessoas.AddAsync(equipePessoas);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid idEquipe, string cpf)
        {
            var equipesPessoas = await _context.EquipesPessoas.FindAsync(idEquipe, cpf);
            if (equipesPessoas != null)
            {
                _context.EquipesPessoas.Remove(equipesPessoas);
                await _context.SaveChangesAsync();
            }
        }

    }
}