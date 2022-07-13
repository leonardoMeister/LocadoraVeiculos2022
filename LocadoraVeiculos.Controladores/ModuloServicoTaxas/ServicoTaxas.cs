﻿using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloTaxas;
using Serilog;

namespace LocadoraVeiculos.Controladores.ModuloServicoTaxas 
{
    public class ServicoTaxas : Controlador<Taxas>
    {
        protected override IRepository<Taxas> PegarRepositorio()
        {
            return new RepositorioTaxas(new MapeadorTaxas());
        }
        protected override AbstractValidator<Taxas> PegarValidador()
        {
            return new ValidadorTaxas();
        }

        public override ValidationResult InserirNovo(Taxas registro)
        {
            var validacaoBanco = TaxasForValidaParaInserir(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("Taxas {TaxasID} inserido com sucesso", registro._id);

                return base.InserirNovo(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Taxas {TaxasID} - {Motivo}",
                        registro._id, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }

        public override ValidationResult Editar(Taxas registro)
        {
            Log.Logger.Debug("Tentando editar uma Taxa... {@f}", registro);

            var validacaoBanco = TaxaForValidaParaEditar(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("Taxa {TaxasID} editada com sucesso", registro._id);

                return base.Editar(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar uma Taxa {TaxasID} - {Motivo}",
                        registro._id, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }

        private ValidationResult TaxaForValidaParaEditar(Taxas registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioTaxas)Repositorio).SelecionarPorDescricao(registro.Descricao);
            if (func1 != null && func1._id != registro._id) valido.Errors.Add(new ValidationFailure("Descricao", "Nao pode ter Descrição repetida"));

            return valido;
        }
        private ValidationResult TaxasForValidaParaInserir(Taxas registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioTaxas)Repositorio).SelecionarPorDescricao(registro.Descricao);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Descricao", "Nao pode ter Descrição repetida"));

            return valido;

        }
    }
}