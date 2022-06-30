using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloFuncionario;
using System;

namespace LocadoraVeiculos.Controladores.ModuloFuncionario
{
    public class ControladorFuncionario : Controlador<Funcionario>
    {
        protected override IRepository<Funcionario> PegarRepositorio()
        {
            return new RepositorioFuncionario(new MapeadorFuncionario());
        }
        protected override AbstractValidator<Funcionario> PegarValidador()
        {
            return new ValidadorFuncionario();
        }

        public override ValidationResult Editar(Funcionario registro)
        {
            var validacaoBanco = FuncionarioForValidoParaEditar(registro);

            if (validacaoBanco.IsValid) return base.Editar(registro);
            else return validacaoBanco;
        }

        public override ValidationResult InserirNovo(Funcionario registro)
        {
            var validacaoBanco = FuncionarioForValidoParaInserir(registro);
            if (validacaoBanco.IsValid) return base.InserirNovo(registro);
            else return validacaoBanco;
        }
        private ValidationResult FuncionarioForValidoParaEditar(Funcionario registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioFuncionario)Repositorio).SelecionarPorNome(registro.Nome);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nomes repetidos"));
            var func2 = ((RepositorioFuncionario)Repositorio).SelecionarPorUsuario(registro.Login);
            if (func2 != null) valido.Errors.Add(new ValidationFailure("login", "Nao pode ter login repetidos"));

            return valido;
        }
        private ValidationResult FuncionarioForValidoParaInserir(Funcionario registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioFuncionario)Repositorio).SelecionarPorNome(registro.Nome);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nomes repetidos"));
            var func2 = ((RepositorioFuncionario)Repositorio).SelecionarPorUsuario(registro.Login);
            if (func2 != null) valido.Errors.Add(new ValidationFailure("login", "Nao pode ter login repetidos"));

            return valido;

        }
    }
}
