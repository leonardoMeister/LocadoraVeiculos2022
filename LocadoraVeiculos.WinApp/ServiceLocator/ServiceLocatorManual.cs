using LocadoraVeiculos.WinApp.ModuloCliente;
using LocadoraVeiculos.WinApp.ModuloCondutores;
using LocadoraVeiculos.WinApp.ModuloFuncionario;
using LocadoraVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraVeiculos.WinApp.ModuloPlanoCobranca;
using LocadoraVeiculos.WinApp.ModuloTaxa;
using LocadoraVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.WinApp.ServiceLocator
{
    public class ServiceLocatorManual
    {
        Dictionary<string, ConfiguracaoBase> controladores;
        public ServiceLocatorManual(Action<string> AtualizarRodape)
        {
            controladores = new Dictionary<string, ConfiguracaoBase>();
            controladores.Add("ControladorGrupoVeiculo", new ControladorGrupoVeiculo(AtualizarRodape));
            controladores.Add("ControladorTaxa", new ControladorTaxa(AtualizarRodape));
            controladores.Add("ControladorCliente", new ControladorCliente(AtualizarRodape));
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(AtualizarRodape));
            controladores.Add("ControladorCondutores", new ControladorCondutores(AtualizarRodape));
            controladores.Add("ControladorPlanoCobranca", new ControladorPlanoCobranca(AtualizarRodape));
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(AtualizarRodape));
        }

        public ConfiguracaoBase Get<T>()
        {
            var tipo = typeof(T);

            var nome = tipo.Name;

            return controladores[nome];
        }
    }
}
