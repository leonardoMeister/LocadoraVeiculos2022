using LocadoraVeiculos.Infra.Configuracao;
using Serilog;

namespace LocadoraVeiculos.Infra.Logging
{
    public class ConfiguracaoLogsLocadora
    {
        public static void ConfigurarEscritaLogs()
        {
            var config = new ConfiguracaoAplicacao();

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Seq("http://localhost:5341")                    
                    .WriteTo.File(config.configuracaoLogs.DiretorioSaida + "/log.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                    .CreateLogger();
        }
    }
}