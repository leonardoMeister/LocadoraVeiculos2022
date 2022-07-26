using LocadoraVeiculos.Infra.Logging;
using LocadoraVeiculos.WinApp.ServiceLocator;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new TelaPrincipalForm());
        }
    }
}