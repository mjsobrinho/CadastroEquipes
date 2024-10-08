<h1>CadastroEquipes</h1>
<h2>API de Cadastro de Pessoas e Equipes</h2>
<p>Foi desenvolvida uma aplicação para cadastrar pessoas, criar equipes e vincular as pessoas às equipes criadas.</p>

<h3>Restrições:</h3>
<ul>
    <li><strong>CPF único:</strong> Não é permitido cadastrar duas pessoas com o mesmo CPF.</li>
    <li><strong>Nome de equipe único:</strong> Não é permitido cadastrar duas equipes com o mesmo nome.</li>
</ul>

<h3>Regras de Negócio:</h3>
<ul>
    <li><strong>Idade Mínima:</strong> A equipe só aceita pessoas com idade maior ou igual à idade mínima configurada para a equipe.</li>
    <li><strong>Sexo:</strong> A equipe aceita pessoas conforme o gênero configurado. Caso a equipe esteja configurada para aceitar "Ambos", ela permitirá qualquer gênero.</li>
</ul>

<h3>Exemplos:</h3>
<ul>
    <li><strong>Equipe configurada com idade mínima de 16 anos e sexo masculino:</strong>
        <ul>
            <li>Aceita apenas pessoas com 16 anos ou mais e do sexo masculino.</li>
        </ul>
    </li>
    <li><strong>Equipe configurada com idade mínima de 18 anos e sexo feminino:</strong>
        <ul>
            <li>Aceita apenas pessoas com 18 anos ou mais e do sexo feminino.</li>
        </ul>
    </li>
    <li><strong>Equipe configurada com idade mínima de 65 anos e gênero "Ambos":</strong>
        <ul>
            <li>Aceita pessoas com 65 anos ou mais, independente do gênero.</li>
        </ul>
    </li>
</ul>

<h3>Criação das Tabelas:</h3>
<p>O script está na pasta <code>CadastroEquipes\src\BD\Scripts</code></p>

<h3>Importante:</h3>
<h4>Configuração da Conexão do Banco:</h4>
<p>Ajustar o arquivo <code>appsettings.json</code></p>
<pre>
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
</pre>
