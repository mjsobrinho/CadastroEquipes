﻿using CadastroPessoaFisica.src.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoaFisica.src.Domain.Entities.Pessoas
{
    [Table("tb_pessoas")]
    public class PessoasDTO
    {
        [Key] // Chave primária
        public string Cpf { get; set; }  // CPF da pessoa

        public string Nome { get; set; } // Nome da pessoa
        
        [Column("dt_nasc")]
        public DateTime Dt_Nasc { get; set; } // Data de nascimento
        [Column("sexo")]
        public string Sexo { get; set; }  // Atributo Sexo como enum

        // Construtor vazio para o Entity Framework
        public PessoasDTO() { }

        // Construtor opcional com parâmetros
        public PessoasDTO(string nome, string cpf, DateTime dt_nasc, string sexo)
        {
            Nome = nome;
            Cpf = cpf;
            Dt_Nasc = dt_nasc;
            Sexo = sexo;
        }
    }
}
