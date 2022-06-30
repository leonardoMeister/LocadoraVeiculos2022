using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloTaxas;

namespace LocadoraVeiculos.Controladores.ModuloControladorTaxas
{
    public class ControladorTaxas : Controlador<Taxas>
    {
        protected override IRepository<Taxas> PegarRepositorio()
        {
            return new RepositorioTaxas(new MapeadorTaxas());
        }
        protected override AbstractValidator<Taxas> PegarValidador()
        {
            return new ValidadorTaxas();
        }

        public override ValidationResult InserirNovo(Taxas registro)
        {
            var validacaoBanco = FuncionarioForValidoParaInserir(registro);
            if (validacaoBanco.IsValid) return base.InserirNovo(registro);
            else return validacaoBanco;
        }
        private ValidationResult FuncionarioForValidoParaEditar(Taxas registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioTaxas)Repositorio).SelecionarPorDescricao(registro.Descricao);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter Descrição repetida"));

            return valido;
        }
        private ValidationResult FuncionarioForValidoParaInserir(Taxas registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioTaxas)Repositorio).SelecionarPorDescricao(registro.Descricao);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter Descrição repetida"));

            return valido;

        }
    }
}
