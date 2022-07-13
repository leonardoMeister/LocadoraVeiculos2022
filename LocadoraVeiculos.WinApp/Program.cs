using FluentValidation;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Infra.Logging;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using LocadoraVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraVeiculos.WinApp.ModuloTaxa;
using LocadoraVeiculos.WinApp.shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();

            ServiceProvider = RegistrarServicos();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(ServiceProvider.GetRequiredService<TelaPrincipalForm>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static ServiceProvider RegistrarServicos()
        {
            var services = new ServiceCollection();

            //configuracoes
            services.AddTransient<ConfiguracaoBase, ConfiguracaoGrupoVeiculo>();

            //validadores
            services.AddSingleton<AbstractValidator<GrupoVeiculos>, ValidadorGrupoVeiculos>();

            //controladores
            services.AddSingleton<ServicoGrupoVeiculos>();
            services.AddSingleton<Controlador<Taxas>, ServicoTaxas>();

            //mapeadores
            services.AddSingleton<MapeadorBase<GrupoVeiculos>, MapeadorGrupoVeiculos>();

            //repositorios            

            //telas
            services.AddTransient<TelaPrincipalForm>();
            services.AddTransient<TelaCadastroTaxaForm>();

            return services.BuildServiceProvider();
        }
    }

    //referencia
    public class classe1
    {
        public ServicoGrupoVeiculos controlador;

        public classe1(ServicoGrupoVeiculos controlador)
        {
            this.controlador = controlador;
        }
    }
}