using FluentValidation;
using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
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

            //validadores
            services.AddSingleton<AbstractValidator<GrupoVeiculos>, ValidadorGrupoVeiculos>();

            //controladores
            services.AddSingleton<ControladorGrupoVeiculos>();

            //mapeadores
            services.AddSingleton<MapeadorBase<GrupoVeiculos>, MapeadorGrupoVeiculos>();

            //repositorios
            services.AddSingleton<IRepositoryGrupoVeiculos, RepositorioGrupoVeiculos>();

            //telas
            services.AddTransient<TelaPrincipalForm>();

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