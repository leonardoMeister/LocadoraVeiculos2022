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
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.Compatilhado
{
    public class LocadoraVeiculosDbContext : DbContext, IContextoPersistencia
    {
        private string connectionString;
       
        public LocadoraVeiculosDbContext(string connectionString)
        {
            //this.connectionString = "Data Source=(LOCALDB)\\MSSQLLOCALDB;Initial Catalog=LocadoraVeiculosTeste;Integrated Security = True;Pooling = false;";
            this.connectionString = connectionString;
        }

        public void GravarDados()
        {
            SaveChanges();
        }
        public void DesfazerAlteracoes()
        {
            var registrosAlterados = ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged)
                .ToList();

            foreach (var registro in registrosAlterados)
            {
                switch (registro.State)
                {
                    case EntityState.Added:
                        registro.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        registro.State = EntityState.Unchanged;
                        break;

                    case EntityState.Modified:
                        registro.State = EntityState.Unchanged;
                        registro.CurrentValues.SetValues(registro.OriginalValues);
                        break;

                    default:
                        break;
                }
            }
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
