using DataAcces.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Projeto360.Aplicacao;
using Projeto360.Servicos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao conteineir
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<ITarefaAplicacao, TarefaAplicacao>();

// Adicione as interfaces de banco de dados
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

//Adicione os serviços
builder.Services.AddScoped<IJsonPlaceHolderServico, JsonPlaceHolderServico>();



builder.Services.AddCors(Options => 
{
    Options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});




builder.Services.AddControllers();

//Adicionar o serviço de banco de dados
builder.Services.AddDbContext<Projeto360Contexto>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Saiba mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{    
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


