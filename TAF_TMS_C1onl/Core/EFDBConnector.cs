using Microsoft.EntityFrameworkCore;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Core
{
    internal class EFDBConnector : DbContext
    {
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Case>? Cases { get; set; }

        public EFDBConnector()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                $"Host={Configurator.DbSettings.Server};" +
                $"Port={Configurator.DbSettings.Port};" +
                $"Database={Configurator.DbSettings.Schema};" +
                $"User Id={Configurator.DbSettings.Username};" +
                $"Password={Configurator.DbSettings.Password};";

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}