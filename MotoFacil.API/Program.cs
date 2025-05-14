using Microsoft.EntityFrameworkCore;
using MotoFacil.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//  Configuração do DbContext com Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Adiciona suporte a controllers
builder.Services.AddControllers();

//  Configura o Swagger com título customizado
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MotoFácil API",
        Version = "v1",
        Description = "API para gerenciamento de usuários e motos no sistema MotoFácil"
    });
});

//  Injeta dependências (caso queira usar serviços futuramente)
// builder.Services.AddScoped<IMotoService, MotoService>();

var app = builder.Build();

//  Configuração de ambiente (Swagger somente em dev)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoFácil API v1");
        c.RoutePrefix = string.Empty; // Swagger direto na raiz
    });
}

// Middleware de autorização
app.UseAuthorization();

//  Roteamento para os controllers
app.MapControllers();

//  Inicializa a aplicação
app.Run();
