namespace CadastroEquipes.src.Application.Comum
{
    public static class CpfValidator
    {
        public static bool ValidarCpf(string cpf)
        {
            // Remove caracteres especiais como . e -
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            // Verifica se o CPF tem 11 dígitos ou é uma sequência repetida
            if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
            {
                return false;
            }

            // Calcula o primeiro dígito verificador
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicador1[i];
            }

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            if (resto != int.Parse(cpf[9].ToString()))
            {
                return false;
            }

            // Calcula o segundo dígito verificador
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            if (resto != int.Parse(cpf[10].ToString()))
            {
                return false;
            }

            return true;
        }
    }
}



