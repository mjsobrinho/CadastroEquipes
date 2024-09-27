using CadastroPessoaFisica.src.Application.Interfaces.Pessoas;
using CadastroPessoaFisica.src.Application.Services.PessoaFisica; 
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;
using CadastroPessoaFisica.src.Infrastructure.Repository.Pessoas;
using CadastroPessoaFisica.src.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CadastroEquipes.src.Application.Interfaces.Equipes;
using CadastroEquipes.src.Application.Services.Equipe;
using CadastroEquipes.src.Domain.Interface.Equipes;
using CadastroEquipes.src.Infrastructure.Repository.Equipes;
using CadastroEquipes.src.Domain.Interface.EquipesPessoas;
using CadastroEquipes.src.Application.Interfaces.EquipesPessoas;
using CadastroEquipes.src.Application.Services.EquipesPessoas;
using CadastroEquipes.src.Infrastructure.Repository.EquipesPessoas;


var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registro do serviço IPessoaFisicaService
builder.Services.AddScoped<IPessoasService, PessoasService>(); 
builder.Services.AddScoped<IPessoaFisicaRepository, PessoasRepository>();

// Registro do serviço EquipesService
builder.Services.AddScoped<IEquipesService, EquipesServices>(); // Ajuste conforme sua implementação
builder.Services.AddScoped<IEquipesRepository, EquipesRepository>();

// Registro do serviço EquipesService
builder.Services.AddScoped<IEquipesPessoasService, EquipesPessoasService>(); 
builder.Services.AddScoped<IEquipesPessoasRepository, EquipesPessoasRepository>();


var app = builder.Build();

// Configura o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
