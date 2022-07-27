using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloDevolucao;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.ModuloDevolucao
{
    public class ServicoDevolucao : ServicoBase<Devolucao>
    {
        public ServicoDevolucao(RepositorioDevolucaoOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }

        protected override AbstractValidator<Devolucao> PegarValidador()
        {
            return new ValidadorDevolucao();
        }
        public override Result<Devolucao> Editar(Devolucao registro)
        {
            var validacaoBanco = DevolucaoForValidoParaEditar(registro);  //VALIDACAO DE BANCO

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
                    Log.Logger.Warning("Falha ao tentar editar Devolucao {DevolucaoID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);

            }
        }
        public override Result<Devolucao> InserirNovo(Devolucao registro)
        {
            var validacaoBanco = DevolucaoForValidoParaInserir(registro);         //VALIDACAO DO BANCO
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
                    Log.Logger.Warning("Falha ao tentar Inserir Devolucao {DevolucaoID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }

        private ValidationResult DevolucaoForValidoParaEditar(Devolucao registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }
        private ValidationResult DevolucaoForValidoParaInserir(Devolucao registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;

        }
    }
}
