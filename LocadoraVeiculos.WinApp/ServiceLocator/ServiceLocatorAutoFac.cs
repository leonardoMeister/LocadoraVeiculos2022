using Autofac;
using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Controladores.ModuloServicoFuncionario;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
using LocadoraVeiculos.WinApp.ModuloCliente;
using LocadoraVeiculos.WinApp.ModuloCondutores;
using LocadoraVeiculos.WinApp.ModuloFuncionario;
using LocadoraVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraVeiculos.WinApp.ModuloPlanoCobranca;
using LocadoraVeiculos.WinApp.ModuloTaxa;
using LocadoraVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.WinApp.shared;
using System;

namespace LocadoraVeiculos.WinApp.ServiceLocator
{
    public class ServiceLocatorAutoFac : IServiceLocator
    {
        Action<string> atualizarRodape;
        public ServiceLocatorAutoFac(Action<string> atualizarRodape)
        {
            this.atualizarRodape = atualizarRodape;
        }

        public T Get<T>() where T : ConfiguracaoBase
        {
            var builder = new ContainerBuilder();

            builder.Register(x => atualizarRodape).AsSelf();

            builder.RegisterType<ServicoCliente>().AsSelf();     
            builder.RegisterType<TabelaClienteControl>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<ServicoCondutores>().AsSelf();
            builder.RegisterType<TabelaCondutoresControl>().AsSelf();
            builder.RegisterType<ControladorCondutores>().AsSelf();

            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<TabelaFuncionarioControl>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<ServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<TabelaGrupoVeiculoControl>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculo>().AsSelf();

            builder.RegisterType<ServicoPlanoCobranca>().AsSelf();
            builder.RegisterType<TabelaPlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoCobranca>().AsSelf();

            builder.RegisterType<ServicoTaxas>().AsSelf();
            builder.RegisterType<TabelaTaxaControl>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<TabelaVeiculoControl>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            IContainer container = builder.Build();
            return container.Resolve<T>();

        }
    }
}
