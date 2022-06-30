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
            var tepo = ((RepositorioFuncionario)Repositorio).SelecionarPorNome("");

            var validacaoBanco = FuncionarioForValidoParaInserir(registro);
            if (validacaoBanco.IsValid) return base.InserirNovo(registro);
            else return validacaoBanco;            
        }
        private ValidationResult FuncionarioForValidoParaEditar(Funcionario registro)
        {
            
            throw new NotImplementedException();
        }
        private ValidationResult FuncionarioForValidoParaInserir(Funcionario registro)
        {
            throw new NotImplementedException();
        }
    }
}
