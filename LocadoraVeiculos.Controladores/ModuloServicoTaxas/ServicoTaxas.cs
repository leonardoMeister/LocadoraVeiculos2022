using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloTaxas;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoTaxas
{
    public class ServicoTaxas : ServicoBase<Taxas>
    {
        public ServicoTaxas(RepositorioTaxaOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }

        protected override AbstractValidator<Taxas> PegarValidador()
        {
            return new ValidadorTaxas();
        }

        protected override ValidationResult RegistroForValidoParaEditarBanco(Taxas registro)
        {
            ValidationResult valido = new ValidationResult();

            Taxas func1 = ((RepositorioTaxaOrm)Repositorio).SelecionarPorDescricao(registro.Descricao);
            if (func1 != null) 
                if(func1.Id != registro.Id)
                    valido.Errors.Add(new ValidationFailure("Descricao", "Nao pode ter Descrição repetida"));

            return valido;
        }

        protected override ValidationResult RegistroForValidoParaInserirBanco(Taxas registro)
        {
            ValidationResult valido = new ValidationResult();

            Taxas func1 = ((RepositorioTaxaOrm)Repositorio).SelecionarPorDescricao(registro.Descricao);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Descricao", "Nao pode ter Descrição repetida"));

            return valido;
        }

    }
}
