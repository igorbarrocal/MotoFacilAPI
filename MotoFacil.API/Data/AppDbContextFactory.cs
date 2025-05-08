using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MotoFacil.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // ⛽ String de conexão diretamente aqui:
        optionsBuilder.UseOracle("User Id=RM555217;Password=020306;Data Source=localhost:1521/XE;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
