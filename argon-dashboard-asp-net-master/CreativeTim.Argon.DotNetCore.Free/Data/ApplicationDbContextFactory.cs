using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CreativeTim.Argon.DotNetCore.Free.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            // ATENÇÃO: Mantenha aqui o provedor de banco original do seu template Argon (ex: UseSqlite, UseNpgsql ou UseSqlServer)
            // Se o Argon veio configurado para PostgreSQL de fábrica:
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=creativeTim;User Id=postgres;Password=creativeTim");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}