using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Repositorio.shared
{
    public abstract class ServicoBase<T> where T : EntidadeBase
    {
        protected IRepository<T> Repositorio;

        protected IContextoPersistencia ContextoPersistencia;

        protected AbstractValidator<T> Validator;
        protected abstract ValidationResult RegistroForValidoParaEditarBanco(T registro);
        protected abstract ValidationResult RegistroForValidoParaInserirBanco(T registro);
        protected abstract AbstractValidator<T> PegarValidador();
        public ServicoBase(IRepository<T> repo, IContextoPersistencia ContextoPersistencia)
        {
            Validator = PegarValidador();
            Repositorio = repo;
            this.ContextoPersistencia = ContextoPersistencia;

        }
        public virtual Result<T> InserirNovo(T registro)
        {
            var validacao = RegistroForValidoParaInserirBanco(registro);
            if (validacao.IsValid)
            {
                return ValidarDominioETentarGravarRegistroAoInserir(registro);
            }
            else
            {
                return GravarErroDeBancoAoInserir(registro, validacao);
            }

        }
        public virtual Result<T> Editar(T registro)
        {
            var validacao = RegistroForValidoParaEditarBanco(registro);

            if (validacao.IsValid)
            {
                return ValidarDominioETentarGravarRegistroAoEditar(registro);
            }
            else
            {
                return GravarErroDeBancoAoEditar(registro, validacao);
            }

        }
        public virtual Result<bool> Existe(Guid id)
        {
            Log.Logger.Debug("Tentando Verificar Existencia de registro... {@f}", id);

            try
            {
                var resultado = Repositorio.Existe(id);

                Log.Logger.Information("Registro {RegistroID} Existe.", id);

                return Result.Ok(resultado);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Verificar Existencia";

                Log.Logger.Error(ex, msgErro + "{RegistroID}", id);

                return Result.Fail(msgErro);
            }

        }
        public virtual Result Excluir(T registro)
        {

            Log.Logger.Debug("Tentando excluir registro... {@f}", registro);

            try
            {
                Repositorio.Excluir(registro.Id);
                ContextoPersistencia.GravarDados();

                Log.Logger.Information("Registro {RegistroID} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o registro";

                Log.Logger.Error("Falha ao tentar Excluir {RegistroType} - {ID} - {Motivo}", registro.GetType(), registro.Id, msgErro);

                return Result.Fail(msgErro);
            }
        }
        public virtual Result<List<T>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(Repositorio.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Registros";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }
        public virtual Result<T> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(Repositorio.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o registro";

                Log.Logger.Error(ex, msgErro + "{RegistroID}", id);

                return Result.Fail(msgErro);
            }
        }

        #region METODOS PRIVADOS
        private Result<T> GravarErroDeBancoAoEditar(T registro, ValidationResult validacao)
        {
            List<Error> listaErros = new List<Error>();

            foreach (var erro in validacao.Errors)
            {
                listaErros.Add(new Error(erro.ErrorMessage));
                Log.Logger.Warning("Falha ao tentar editar Registro {TipoRegistro} - {RegistroId} - {Motivo}",
                    registro.GetType(), registro.Id, erro.ErrorMessage);
            }
            return Result.Fail(listaErros);
        }
        private Result ValidarRegistroDominio(T registro)
        {
            var resultado = Validator.Validate(registro);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultado.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();

        }
        private Result<T> GravarErroDeBancoAoInserir(T registro, ValidationResult validacao)
        {
            List<Error> listaErros = new List<Error>();

            foreach (var erro in validacao.Errors)
            {
                listaErros.Add(new Error(erro.ErrorMessage));
                Log.Logger.Warning("Falha ao tentar Inserir Registro {TipoRegistro} - {RegistroID} - {Motivo}",
                    registro.GetType(), registro.Id, erro.ErrorMessage);
            }
            return Result.Fail(listaErros);
        }
        private Result<T> ValidarDominioETentarGravarRegistroAoEditar(T registro)
        {
            Log.Logger.Warning("Tentando Editar Registro: {RegistroType} - {ID}", registro.GetType(), registro.Id);

            Result resultadoValidacao = ValidarRegistroDominio(registro);

            if (resultadoValidacao.IsFailed)
            {
                return GravandoMensagemErroDominioAoEditar(registro, resultadoValidacao);
            }
            else
            {
                return EditandoRegistro(registro);
            }

        }
        private Result<T> EditandoRegistro(T registro)
        {
            try
            {
                Repositorio.Editar(registro);
                ContextoPersistencia.GravarDados();

                Log.Logger.Information("Registro {RegistroID} editado com sucesso", registro.Id);

                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Editar o Registro";

                Log.Logger.Warning("Falha ao tentar Editar {RegistroType} - {ID} - {Motivo}", registro.GetType(), registro.Id, msgErro);

                return Result.Fail(msgErro);
            }
        }
        private Result<T> GravandoMensagemErroDominioAoEditar(T registro, Result resultadoValidacao)
        {
            foreach (var erro in resultadoValidacao.Errors)
            {
                Log.Logger.Warning("Falha ao tentar Editar {RegistroType} - {ID} - {Motivo}", registro.GetType(), registro.Id, erro.Message);
            }

            return Result.Fail(resultadoValidacao.Errors);
        }
        private Result<T> ValidarDominioETentarGravarRegistroAoInserir(T registro)
        {
            Log.Logger.Warning("Tentando inserir Registro: {RegistroType} - {ID}", registro.GetType(), registro.Id);

            Result resultadoValidacao = ValidarRegistroDominio(registro); //validacao dominio

            if (resultadoValidacao.IsFailed)
            {
                return GravandoMensagemErroDominioAoInserir(registro, resultadoValidacao);
            }
            else
            {
                return InserindoRegistro(registro);
            }

        }
        private Result<T> InserindoRegistro(T registro)
        {
            try
            {
                Repositorio.InserirNovo(registro);
                ContextoPersistencia.GravarDados();
                Log.Logger.Information("Registro {RegistroID} inserido com sucesso", registro.Id);

                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Registro";
                Log.Logger.Error("Falha ao tentar inserir {RegistroType} - {ID} - {Motivo}", registro.GetType(), registro.Id, msgErro);

                return Result.Fail(msgErro);
            }
        }
        private Result<T> GravandoMensagemErroDominioAoInserir(T registro, Result resultadoValidacao)
        {
            foreach (var erro in resultadoValidacao.Errors)
            {
                Log.Logger.Warning("Falha ao tentar inserir {RegistroType} - {ID} - {Motivo}", registro.GetType(), registro.Id, erro.Message);
            }

            return Result.Fail(resultadoValidacao.Errors);
        }
        #endregion

    }
}