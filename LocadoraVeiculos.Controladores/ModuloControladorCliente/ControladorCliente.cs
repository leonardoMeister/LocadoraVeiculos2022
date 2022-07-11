using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloCliente;
using Serilog;

namespace LocadoraVeiculos.Controladores.ModuloControladorCliente
{
    public class ControladorCliente : Controlador<Cliente>
    {

        protected override IRepository<Cliente> PegarRepositorio()
        {
            return new RepositorioCliente(new MapeadorCliente());
        }

        protected override AbstractValidator<Cliente> PegarValidador()
        {
            return new ValidadorCliente();
        }

        public override ValidationResult Editar(Cliente registro)
        {
            Log.Logger.Debug("Tentando editar um Cliente... {@f}", registro);

            var validacaoBanco = FuncionarioForValidoParaEditar(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("Cliente {ClienteNome} editado com sucesso", registro.Nome);

                return base.Editar(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Cliente {ClienteNome} - {Motivo}",
                        registro.Nome, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }

        public override ValidationResult InserirNovo(Cliente registro)
        {
            Log.Logger.Debug("Tentando inserir um Cliente... {@f}", registro);

            var validacaoBanco = FuncionarioForValidoParaInserir(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("Cliente {ClienteNome} inserido com sucesso", registro.Nome);

                return base.InserirNovo(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Cliente {ClienteNome} - {Motivo}",
                        registro.Nome, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }


        private ValidationResult FuncionarioForValidoParaEditar(Cliente registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioCliente)Repositorio).SelecionarPorCpf(registro.Cpf);
            if (func1 != null && func1._id != registro._id)
            {
                if (func1.Cpf != "   .   .   -")
                {
                    valido.Errors.Add(new ValidationFailure("Cpf", "Nao pode ter Cpf repetido"));
                }

            }

            var func2 = ((RepositorioCliente)Repositorio).SelecionarPorCnpj(registro.Cnpj);
            if (func2 != null && func2._id != registro._id)
            {
                if (func2.Cnpj != "  .   .   /    -")
                {
                    valido.Errors.Add(new ValidationFailure("Cnpj", "Nao pode ter Cnpj repetido"));
                }

            }

            return valido;
        }
        private ValidationResult FuncionarioForValidoParaInserir(Cliente registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioCliente)Repositorio).SelecionarPorCpf(registro.Cpf);
            if (func1 != null)
            {
                if (func1.Cpf != "   .   .   -")
                {
                    valido.Errors.Add(new ValidationFailure("Cpf", "Nao pode ter Cpf repetido"));
                }

            }
            var func2 = ((RepositorioCliente)Repositorio).SelecionarPorCnpj(registro.Cnpj);
            if (func2 != null)
            {
                if (func2.Cnpj != "  .   .   /    -")
                {
                    valido.Errors.Add(new ValidationFailure("Cnpj", "Nao pode ter Cnpj repetido"));
                }

            }

            return valido;

        }
    }
}
