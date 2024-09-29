using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroEquipes.src.Domain.Entities.EquipesPessoas
{
    
    public class EquipesPessoasRelatDTO
    {
        public Guid id_Equipe { get; set; }  // Chave estrangeira para tb_equipes
        
        public string Cpf { get; set; }      // Chave estrangeira para tb_pessoa
        public string nome { get; set; }
        public string nm_equipe { get; set; }
        public string sexo { get; set; }
        public int idade { get; set; }
    }
}
