using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroEquipes.src.Domain.Entities.EquipesPessoas
{
    [PrimaryKey(nameof(Id_Equipe), nameof(Cpf))]
    [Table("tb_equipes_pessoas")]
    public class EquipesPessoasDTO
    {
        public Guid Id_Equipe { get; set; }  // Chave estrangeira para tb_equipes
        
        public string Cpf { get; set; }      // Chave estrangeira para tb_pessoa

        public int idade { get; set; }
    }
}
