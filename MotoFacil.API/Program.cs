using Microsoft.EntityFrameworkCore;
using MotoFacil.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));


builder.Services.AddControllers();


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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoFácil API v1");
    c.RoutePrefix = "swagger"; 
});


app.UseAuthorization();
app.MapControllers();
app.Run();
