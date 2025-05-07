using Microsoft.EntityFrameworkCore;
using MotoFacil.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do EF Core com Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilita Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Ativa se quiser HTTPS

app.UseAuthorization();

app.MapControllers();

app.Run();
