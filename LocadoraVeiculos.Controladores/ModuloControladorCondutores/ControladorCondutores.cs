using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloCondutores;
using Serilog;
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
            var validacaoBanco = CondutorForValidoParaEditar(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("Condutor {CondutorNome} editado com sucesso", registro.Nome);

                return base.Editar(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Condutor {CondutorNome} - {Motivo}",
                        registro.Nome, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }

        public override ValidationResult InserirNovo(Condutores registro)
        {
            var validacaoBanco = CondutorForValidoParaInserir(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("Condutor {CondutorNome} inserido com sucesso", registro.Nome);

                return base.InserirNovo(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Condutor {CondutorNome} - {Motivo}",
                        registro.Nome, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }
        private ValidationResult CondutorForValidoParaEditar(Condutores registro)
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
        private ValidationResult CondutorForValidoParaInserir(Condutores registro)
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
