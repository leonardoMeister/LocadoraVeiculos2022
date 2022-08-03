using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace LocadoraVeiculos.Infra.Configuracao
{
    public class ConfiguracaoAplicacao
    {
        public ConnectionStrings connectionStrings { get; set; }
        public PrecosCombustiveis precosCombustiveis { get; set; }
        public ConfiguracaoLogs configuracaoLogs { get; set; }
        public ConfiguracaoAplicacao()
        {

            IConfiguration configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            string conectionString = configuracao
               .GetSection("ConnectionStrings")
               .GetSection("SqlServer")
               .Value;
            string configLogs = configuracao
               .GetSection("ConfiguracaoLogs")
               .GetSection("DiretorioSaida")
               .Value;

            configuracaoLogs = new ConfiguracaoLogs { DiretorioSaida = configLogs };
            connectionStrings = new ConnectionStrings { SqlServer = conectionString };

            decimal gasolina = Convert.ToDecimal(configuracao.GetSection("PrecosCombustivel").GetSection("Gasolina").Value);
            decimal diesel = Convert.ToDecimal(configuracao.GetSection("PrecosCombustivel").GetSection("Diesel").Value);
            decimal etanol = Convert.ToDecimal(configuracao.GetSection("PrecosCombustivel").GetSection("Etanol").Value);
            precosCombustiveis = new PrecosCombustiveis { Diesel = diesel, Gasolina = gasolina, Etanol = etanol };
        }
        public class ConnectionStrings
        {
            public string SqlServer { get; set; }
        }
        public class ConfiguracaoLogs
        {
            public string DiretorioSaida { get; set; }
        }
        public class PrecosCombustiveis
        {
            public decimal Gasolina { get; set; }
            public decimal Diesel { get; set; }
            public decimal Etanol { get; set; }
        }
    }
}
