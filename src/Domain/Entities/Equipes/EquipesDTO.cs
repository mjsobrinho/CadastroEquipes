using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroEquipes.src.Domain.Entities.Equipes
{
    [Table("tb_equipes")]
    public class EquipeDTO
    {
        [Key] // Chave primária
        public Guid Id { get; set; } // Chave primária do tipo GUID


        [StringLength(100)] // Limita o tamanho do nome a 100 caracteres
        public string Nm_Equipe { get; set; } // Nome da equipe

        public int Idad_Mini { get; set; } // Idade mínima

        public string Sexo { get; set; } // Sexo

        // Construtor padrão
        public EquipeDTO()
        {
            Id = Guid.NewGuid(); // Gera um novo GUID por padrão
        }

        // Construtor adicional com parâmetros
        public EquipeDTO(string nm_equipe,  int idadeMin, string sexo)
        {
            Id = Guid.NewGuid();
            Nm_Equipe = nm_equipe;
            Idad_Mini = idadeMin;
            Sexo = sexo;
        }
    }
}
