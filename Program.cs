using CadastroPessoaFisica.src.Application.Interfaces.PessoaFisica;
using CadastroPessoaFisica.src.Application.Services.PessoaFisica; // Ajuste conforme o namespace correto
using CadastroPessoaFisica.src.Domain.Interface.PessoaFisica;
using CadastroPessoaFisica.src.Infrastructure.Repository.PessoaFisica;
using CadastroPessoaFisica.src.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Adicione servi�os ao cont�iner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Registro do servi�o IPessoaFisicaService
builder.Services.AddScoped<IPessoaFisicaService, PessoaFisicaService>(); // Ajuste conforme sua implementa��o
builder.Services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>(); // Ajuste conforme sua implementa��o

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
