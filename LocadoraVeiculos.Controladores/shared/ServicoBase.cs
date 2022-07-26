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

        protected AbstractValidator<T> Validator;

        public ServicoBase(IRepository<T> repo)
        {
            Validator = PegarValidador();
            Repositorio = repo;
            
        }

        protected abstract AbstractValidator<T> PegarValidador();

        private Result ValidarRegistro(T registro)
        {
            var resultado = Validator.Validate(registro);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultado.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();

        }

        public virtual Result<T> InserirNovo(T registro)
        {
            Log.Logger.Warning("Tentando inserir Registro: {RegistroType} - {ID}", registro.GetType(), registro.Id);

            Result resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {                    
                    Log.Logger.Warning("Falha ao tentar inserir {RegistroType} - {ID} - {Motivo}", registro.GetType(), registro.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                Repositorio.InserirNovo(registro);

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

        public virtual Result<T> Editar( T registro)
        {
            Log.Logger.Warning("Tentando Editar Registro: {RegistroType} - {ID}", registro.GetType(), registro.Id);

            Result resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar Editar {RegistroType} - {ID} - {Motivo}", registro.GetType(), registro.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                Repositorio.Editar(registro);

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
    }
}