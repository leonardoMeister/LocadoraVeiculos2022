using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
namespace LocadoraVeiculos.Repositorio.shared
{
    public abstract class Controlador<T> where T : EntidadeBase
    {
        protected IRepository<T> Repositorio;

        protected AbstractValidator<T> Validator;

        public Controlador(AbstractValidator<T> validator, IRepository<T> repositorio)
        {
            Validator = validator;
            Repositorio = repositorio;
        }

        public virtual ValidationResult InserirNovo(T registro)
        {
            var resultadoValidacao = Validator.Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                Repositorio.InserirNovo(registro);
            }
            return resultadoValidacao;
        }

        public virtual ValidationResult Editar(int id, T registro)
        {
            var resultadoValidacao = Validator.Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                Repositorio.Editar(id, registro);
            }
            return resultadoValidacao;
        }

        public virtual bool Existe(int id)
        {
            return Repositorio.Existe(id);
        }        

        public virtual ValidationResult Excluir(int id)
        {
            var resultadoValidacao = new ValidationResult();
            try
            {
                Repositorio.Excluir(id);
            }
            catch (Exception e)
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", $"{e.Message}"));
            }

            return resultadoValidacao;
        }

        public virtual List<T> SelecionarTodos()
        {
            return Repositorio.SelecionarTodos();
        }

        public virtual T SelecionarPorId(int id)
        {
            return Repositorio.SelecionarPorId(id);
        }
    }
}