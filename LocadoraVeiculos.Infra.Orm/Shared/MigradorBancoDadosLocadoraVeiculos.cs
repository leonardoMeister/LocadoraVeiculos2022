using LocadoraVeiculos.Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.Compatilhado
{
    public class MigradorBancoDadosLocadoraVeiculos
    {
        public static void AtualizarBancoDados()
        {
            var config = new ConfiguracaoAplicacao();
            
            var db = new LocadoraVeiculosDbContext(config.connectionStrings.SqlServer);

            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
                db.Database.Migrate();
        }
    }
}
