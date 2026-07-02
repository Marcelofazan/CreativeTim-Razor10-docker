using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using CreativeTim.Argon.DotNetCore.Free.Models.Identity; // Garanta que este usando aponta para o ApplicationRole

namespace CreativeTim.Argon.DotNetCore.Free.Data
{
    // ALTERE A LINHA ABAIXO PARA ESTE FORMATO DE TRÊS PARÂMETROS GENERÍCOS:
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IDataProtectionKeyContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tabela criada nos passos anteriores para chaves criptográficas
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Mapeamentos específicos do template Argon...
        }
    }
}