using LocadoraVeiculos.Infra.Configuracao;
using Microsoft.EntityFrameworkCore.Design;

namespace LocadoraVeiculos.Infra.Orm.Compatilhado
{
    public class LocadoraVeiculosDbContextFactory : IDesignTimeDbContextFactory<LocadoraVeiculosDbContext>
    {
        public LocadoraVeiculosDbContext CreateDbContext(string[] args)
        {
            var config = new ConfiguracaoAplicacao();           
            
            return new LocadoraVeiculosDbContext(config.connectionStrings.SqlServer);
        }
    }
}
