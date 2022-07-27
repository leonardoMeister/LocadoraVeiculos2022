using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos
{
    public class ServicoGrupoVeiculos : ServicoBase<GrupoVeiculos>
    {
        public ServicoGrupoVeiculos(RepositorioGrupoVeiculoOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }        

        protected override AbstractValidator<GrupoVeiculos> PegarValidador()
        {
            return new ValidadorGrupoVeiculos();
        }

        public override Result<GrupoVeiculos> InserirNovo(GrupoVeiculos registro)
        {
            var validacaoBanco = GrupoVeiculosForValidoParaInserir(registro);         //VALIDACAO DO BANCO
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
                    Log.Logger.Warning("Falha ao tentar inserir um GrupoVeiculos {GrupoVeiculosID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }

        public override Result<GrupoVeiculos> Editar(GrupoVeiculos registro)
        {
            var validacaoBanco = GrupoVeiculosForValidoParaEditar(registro);  //VALIDACAO DE BANCO

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
                    Log.Logger.Warning("Falha ao tentar editar GrupoVeiculos {GrupoVeiculosID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);

            }
        }

        private ValidationResult GrupoVeiculosForValidoParaEditar(GrupoVeiculos registro)
        {
            ValidationResult valido = new ValidationResult();

            GrupoVeiculos func1 = ((RepositorioGrupoVeiculoOrm)Repositorio).SelecionarPorNome(registro.NomeGrupo);
            if (func1 != null && func1.Id != registro.Id) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nome repetido"));

            return valido;
        }
        private ValidationResult GrupoVeiculosForValidoParaInserir(GrupoVeiculos registro)
        {
            ValidationResult valido = new ValidationResult();

            GrupoVeiculos func1 = ((RepositorioGrupoVeiculoOrm)Repositorio).SelecionarPorNome(registro.NomeGrupo);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nome repetido"));

            return valido;

        }
    }
}
