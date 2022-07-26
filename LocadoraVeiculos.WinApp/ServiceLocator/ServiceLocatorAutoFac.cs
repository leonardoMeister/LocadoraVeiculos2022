﻿using Autofac;
using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Controladores.ModuloServicoFuncionario;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloCliente;
using LocadoraVeiculos.Infra.Orm.ModuloCondutores;
using LocadoraVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Orm.ModuloTaxas;
using LocadoraVeiculos.Infra.Orm.ModuloVeiculo;
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
            builder.RegisterType<LocadoraVeiculosDbContext>().AsSelf();

            builder.RegisterType<RepositorioClienteOrm>().AsSelf();
            builder.RegisterType<ServicoCliente>().AsSelf();     
            builder.RegisterType<TabelaClienteControl>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioCondutorOrm>().AsSelf();
            builder.RegisterType<ServicoCondutores>().AsSelf();
            builder.RegisterType<TabelaCondutoresControl>().AsSelf();
            builder.RegisterType<ControladorCondutores>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioOrm>().AsSelf();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<TabelaFuncionarioControl>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioGrupoVeiculoOrm>().AsSelf();
            builder.RegisterType<ServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<TabelaGrupoVeiculoControl>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculo>().AsSelf();

            builder.RegisterType<RepositorioPlanoCobrancaOrm>().AsSelf();
            builder.RegisterType<ServicoPlanoCobranca>().AsSelf();
            builder.RegisterType<TabelaPlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoCobranca>().AsSelf();

            builder.RegisterType<RepositorioTaxaOrm>().AsSelf();
            builder.RegisterType<ServicoTaxas>().AsSelf();
            builder.RegisterType<TabelaTaxaControl>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioVeiculoOrm>().AsSelf();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<TabelaVeiculoControl>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            IContainer container = builder.Build();
            return container.Resolve<T>();

        }
    }
}
