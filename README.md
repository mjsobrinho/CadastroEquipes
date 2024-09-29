# CadastroEquipes
API de Cadastro de Pessoas e Equipes
Foi desenvolvida uma aplicação para cadastrar pessoas, criar equipes e vincular as pessoas às equipes criadas.

Restrições:
CPF único: Não é permitido cadastrar duas pessoas com o mesmo CPF.
Nome de equipe único: Não é permitido cadastrar duas equipes com o mesmo nome.
Regras de Negócio:
Idade Mínima: A equipe só aceita pessoas com idade maior ou igual à idade mínima configurada para a equipe.
Sexo: A equipe aceita pessoas conforme o gênero configurado. Caso a equipe esteja configurada para aceitar "Ambos", ela permitirá qualquer gênero.
Exemplos:
Equipe configurada com idade mínima de 16 anos e sexo masculino:
Aceita apenas pessoas com 16 anos ou mais e do sexo masculino.

Equipe configurada com idade mínima de 18 anos e sexo feminino:
Aceita apenas pessoas com 18 anos ou mais e do sexo feminino.

Equipe configurada com idade mínima de 65 anos e gênero "Ambos":
Aceita pessoas com 65 anos ou mais, independente do gênero.

Criação das tabelas:
O script está na pasta CadastroEquipes\src\BD\Scripts

Importante:
Configuração do conexão do banco:

Ajustar o arquivo appsettings.json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=Marconios-7010;Database=UBS_Dev;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

