using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LocadoraVeiculos.Infra.Orm.Compatilhado
{
    public class LocadoraVeiculosDbContext : DbContext, IContextoPersistencia
    {
        private string connectionString;

        public DbSet<Taxas> Taxas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<GrupoVeiculos> GrupoVeiculos { get; set; }
        public DbSet<Condutores> Condutores { get; set; }
        public DbSet<PlanoCobranca> PlanoCobranca { get; set; }
        public LocadoraVeiculosDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

            ILoggerFactory loggerFactory = LoggerFactory.Create((x) =>
            {
                x.AddSerilog(Log.Logger);//instalar o pacote Serilog.Extensions.Logging
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dllComConfiguracoesOrm = typeof(LocadoraVeiculosDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

            modelBuilder.ApplyConfiguration(new MapeadorClienteOrm());
        }
    }
}
