using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloCondutores;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoCondutores
{
    public class ServicoCondutores : ServicoBase<Condutores>
    {
        public ServicoCondutores(RepositorioCondutorOrm repo, IContextoPersistencia contexto) : base(repo,contexto)
        {

        }

        protected override AbstractValidator<Condutores> PegarValidador()
        {
            return new ValidadorCondutores();
        }

        public override Result<Condutores> Editar(Condutores registro)
        {
            var validacaoBanco = CondutorForValidoParaEditar(registro);  //VALIDACAO DE BANCO

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
                    Log.Logger.Warning("Falha ao tentar editar Condutor {CondutorId} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);

            }
        }

        public override Result<Condutores> InserirNovo(Condutores registro)
        {
            var validacaoBanco = CondutorForValidoParaInserir(registro);         //VALIDACAO DO BANCO
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
                    Log.Logger.Warning("Falha ao tentar Inserir Condutor {CondutorID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }
        private ValidationResult CondutorForValidoParaEditar(Condutores registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }
        private ValidationResult CondutorForValidoParaInserir(Condutores registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;

        }
    }
}
