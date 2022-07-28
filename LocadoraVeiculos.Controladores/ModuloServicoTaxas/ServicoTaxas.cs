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

        public override Result<Taxas> InserirNovo(Taxas registro)
        {
            var validacaoBanco = TaxasForValidaParaInserir(registro);         //VALIDACAO DO BANCO
            if (validacaoBanco.IsValid)
            {
                return base.InserirNovo(registro);                                  //VALIDACAO DO DOMINIO
            }
            else
            {
                List<Error> listaErros = new List<Error>();

                foreach (var erro in validacaoBanco.Errors)
                {
                    listaErros.Add(new Error(erro.ErrorMessage));
                    Log.Logger.Warning("Falha ao tentar inserir um Taxas {TaxasID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }

        public override Result<Taxas> Editar(Taxas registro)
        {
            var validacaoBanco = TaxaForValidaParaEditar(registro);  //VALIDACAO DE BANCO

            if (validacaoBanco.IsValid)
            {
                return base.Editar(registro);                              //VALIDACAO DE DOMINIO
            }
            else
            {
                List<Error> listaErros = new List<Error>();

                foreach (var erro in validacaoBanco.Errors)
                {
                    listaErros.Add(new Error(erro.ErrorMessage));
                    Log.Logger.Warning("Falha ao tentar editar uma Taxa {TaxasID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);

            }
        }

        private ValidationResult TaxaForValidaParaEditar(Taxas registro)
        {
            ValidationResult valido = new ValidationResult();

            Taxas func1 = ((RepositorioTaxaOrm)Repositorio).SelecionarPorDescricao(registro.Descricao);
            if (func1 != null && func1.Id != registro.Id) valido.Errors.Add(new ValidationFailure("Descricao", "Nao pode ter Descrição repetida"));

            return valido;
        }
        private ValidationResult TaxasForValidaParaInserir(Taxas registro)
        {
            ValidationResult valido = new ValidationResult();

            Taxas func1 = ((RepositorioTaxaOrm)Repositorio).SelecionarPorDescricao(registro.Descricao);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Descricao", "Nao pode ter Descrição repetida"));

            return valido;

        }
    }
}
