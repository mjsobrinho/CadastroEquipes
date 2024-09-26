using CadastroPessoaFisica.src.Domain.Entities;

namespace CadastroEquipes.src.Domain.Entities
{
    public class BaseDTO : ResponseBase
    {
        public BaseDTO() { }

        public DateTime? dt_atu { get; set; }

        public string cd_user_manu { get; set; }
       
    }
}
