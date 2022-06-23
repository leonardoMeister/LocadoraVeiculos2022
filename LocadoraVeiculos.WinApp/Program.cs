using FluentValidation;
using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
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

            services.AddSingleton<AbstractValidator<GrupoVeiculos>, ValidadorGrupoVeiculos>();
            services.AddSingleton<ControladorGrupoVeiculos>();
            services.AddSingleton<MapeadorBase<GrupoVeiculos>, MapeadorGrupoVeiculos>();
            services.AddSingleton<IRepositoryGrupoVeiculos, RepositorioGrupoVeiculos>();
            services.AddTransient<TelaPrincipalForm>();

            return services.BuildServiceProvider();
        }
    }
}