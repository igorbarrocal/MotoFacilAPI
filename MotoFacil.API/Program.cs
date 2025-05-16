using Microsoft.EntityFrameworkCore;
using MotoFacil.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

// Adiciona suporte a controllers
builder.Services.AddControllers();

// Configura Swagger (sempre disponível, não só em dev)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MotoFácil API",
        Version = "v1",
        Description = "API para gerenciamento de usuários e motos no sistema MotoFácil"
    });
});

var app = builder.Build();

// Swagger ativado sempre (não só em dev)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoFácil API v1");
    c.RoutePrefix = "swagger"; // Agora acessível em /swagger
});

// Middleware padrão
app.UseAuthorization();
app.MapControllers();
app.Run();
