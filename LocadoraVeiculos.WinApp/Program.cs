using FluentValidation;
using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloControladorTaxas;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using LocadoraVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraVeiculos.WinApp.ModuloTaxa;
using LocadoraVeiculos.WinApp.shared;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            services.AddTransient<ConfiguracaoBase<GrupoVeiculos>, ConfiguracaoGrupoVeiculo>();

            //validadores
            services.AddSingleton<AbstractValidator<GrupoVeiculos>, ValidadorGrupoVeiculos>();

            //controladores
            services.AddSingleton<ControladorGrupoVeiculos>();
            services.AddSingleton<Controlador<Taxas>, ControladorTaxas>();

            //mapeadores
            services.AddSingleton<MapeadorBase<GrupoVeiculos>, MapeadorGrupoVeiculos>();

            //repositorios
            services.AddSingleton<IRepositoryGrupoVeiculos, RepositorioGrupoVeiculos>();

            //telas
            services.AddTransient<TelaPrincipalForm>();
            services.AddTransient<TelaCadastroTaxaForm>();

            return services.BuildServiceProvider();
        }
    }

    //referencia
    public class classe1
    {
        public ControladorGrupoVeiculos controlador;

        public classe1(ControladorGrupoVeiculos controlador)
        {
            this.controlador = controlador;
        }
    }
}