using FluentValidation;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.RepositorioProject.shared;

namespace LocadoraVeiculos.Repositorio.shared
{
    public abstract class Repositorio<T, TValidador, TMapeador>
        where T : EntidadeBase
        where TValidador : AbstractValidator<T>, new()
        where TMapeador : MapeadorBase<T>, new()
    {

        protected abstract string SqlUpdate { get; }
        protected abstract string SqlDelete { get; }
        protected abstract string SqlInsert { get; }
        protected abstract string SqlSelectAll { get; }
        protected abstract string SqlSelectId { get; }
        protected abstract string SqlExiste { get; }

        public virtual ValidationResult InserirNovo(T registro)
        {

            var resultadoValidacao = new TValidador().Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                int id = DataBase.Insert(SqlInsert, new TMapeador().ObtemParametrosRegistro(registro));
                registro._id = id;
            }
            return resultadoValidacao;
        }
        public virtual ValidationResult Editar(int id, T registro)
        {
            var resultadoValidacao = new TValidador().Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                registro._id = id;
                DataBase.Update(SqlUpdate, new TMapeador().ObtemParametrosRegistro(registro));
            }
            return resultadoValidacao;
        }
        public virtual bool Existe(int id)
        {
            return DataBase.Exists(SqlExiste, new TMapeador().AdicionarParametro("ID", id));
        }
        public virtual ValidationResult Excluir(int id)
        {
            var resultadoValidacao = new ValidationResult();
            try
            {
                DataBase.Delete(SqlDelete, new TMapeador().AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));
                return resultadoValidacao;
            }

            return resultadoValidacao;
        }
        public virtual List<T> SelecionarTodos()
        {
            return DataBase.GetAll(SqlSelectAll, new TMapeador().ConverterEmRegistro);
        }
        public virtual T SelecionarPorId(int id)
        {
            var mapa = new TMapeador();
            return DataBase.Get(SqlSelectId, mapa.ConverterEmRegistro, mapa.AdicionarParametro("ID", id));
        }
    }
}
