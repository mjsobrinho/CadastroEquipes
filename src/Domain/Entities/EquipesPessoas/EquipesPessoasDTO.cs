using System.ComponentModel.DataAnnotations;

namespace CadastroEquipes.src.Domain.Entities.EquipesPessoas
{
    public class EquipePessoasDTO
    {
        [Key] // Chave primária
        public Guid IdEquipe { get; set; }  // Chave estrangeira para tb_equipes
        public string Cpf { get; set; }      // Chave estrangeira para tb_pessoa
    }
}
