using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloCondutores;
using System;

namespace LocadoraVeiculos.Controladores.ModuloCondutores
{
    public class ControladorCondutores : Controlador<Condutores>
    {
        protected override IRepository<Condutores> PegarRepositorio()
        {
            return new RepositorioCondutores(new MapeadorCondutores());
        }

        protected override AbstractValidator<Condutores> PegarValidador()
        {
            return new ValidadorCondutores();
        }

        public override ValidationResult Editar(Condutores registro)
        {
            var validacaoBanco = FuncionarioForValidoParaEditar(registro);

            if (validacaoBanco.IsValid) return base.Editar(registro);
            else return validacaoBanco;
        }

        public override ValidationResult InserirNovo(Condutores registro)
        {
            var validacaoBanco = FuncionarioForValidoParaInserir(registro);
            if (validacaoBanco.IsValid) return base.InserirNovo(registro);
            else return validacaoBanco;
        }
        private ValidationResult FuncionarioForValidoParaEditar(Condutores registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioCondutores)Repositorio).SelecionarPorCpf(registro.Cpf);
            if (func1 != null && func1._id != registro._id)
            {
                if (func1.Cpf != "   .   .   -")
                {
                    valido.Errors.Add(new ValidationFailure("Cpf", "Nao pode ter Cpf repetido"));
                }

            }

            return valido;
        }
        private ValidationResult FuncionarioForValidoParaInserir(Condutores registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioCondutores)Repositorio).SelecionarPorCpf(registro.Cpf);
            if (func1 != null)
            {
                if (func1.Cpf != "   .   .   -")
                {
                    valido.Errors.Add(new ValidationFailure("Cpf", "Nao pode ter Cpf repetido"));
                }

            }

            return valido;

        }
    }
}
