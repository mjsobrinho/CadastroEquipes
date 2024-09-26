using CadastroPessoaFisica.src.Application.Interfaces.PessoaFisica;
using CadastroPessoaFisica.src.Application.Services.PessoaFisica; 
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;
using CadastroPessoaFisica.src.Infrastructure.Repository.PessoaFisica;
using CadastroPessoaFisica.src.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CadastroEquipes.src.Application.Interfaces.Equipes;
using CadastroEquipes.src.Application.Services.Equipe;
using CadastroEquipes.src.Domain.Interface.Equipes;
using CadastroEquipes.src.Infrastructure.Repository.Equipes;


var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registro do serviço IPessoaFisicaService
builder.Services.AddScoped<IPessoaFisicaService, PessoaFisicaService>(); 
builder.Services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();

// Registro do serviço EquipesService
builder.Services.AddScoped<IEquipesService, EquipesServices>(); // Ajuste conforme sua implementação
builder.Services.AddScoped<IEquipesRepository, EquipesRepository>();

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
