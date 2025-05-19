using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MotoFacil.Data;

namespace MotoFacil
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            
            optionsBuilder.UseOracle("Data Source=oracle.fiap.com.br:1521/orcl;User ID=RM555217;Password=020306;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
