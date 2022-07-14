using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloCliente;
using Serilog;

namespace LocadoraVeiculos.Controladores.ModuloServicoCliente
{ 
    public class ServicoCliente : ServicoBase<Cliente> 
    {

        protected override IRepository<Cliente> PegarRepositorio()
        {
            return new RepositorioCliente(new MapeadorCliente());
        }

        protected override AbstractValidator<Cliente> PegarValidador()
        {
            return new ValidadorCliente();
        }

        public override ValidationResult InserirNovo(Cliente registro)
        {
            Log.Logger.Debug("Tentando inserir um Cliente... {@f}", registro);

            var validacaoBanco = FuncionarioForValidoParaInserir(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("Cliente {ClienteID} inserido com sucesso", registro._id);

                return base.InserirNovo(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Cliente {ClienteID} - {Motivo}",
                        registro._id, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }

        public override ValidationResult Editar(Cliente registro)
        {
            Log.Logger.Debug("Tentando editar um Cliente... {@f}", registro);

            var validacaoBanco = FuncionarioForValidoParaEditar(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("Cliente {ClienteID} editado com sucesso", registro._id);

                return base.Editar(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Cliente {ClienteID} - {Motivo}",
                        registro._id, erros.ErrorMessage);
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
