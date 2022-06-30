using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;

namespace LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos
{
    public class ControladorGrupoVeiculos : Controlador<GrupoVeiculos>
    {
        protected override IRepository<GrupoVeiculos> PegarRepositorio()
        {
            return new RepositorioGrupoVeiculos(new MapeadorGrupoVeiculos());
        }

        protected override AbstractValidator<GrupoVeiculos> PegarValidador()
        {
            return new ValidadorGrupoVeiculos();
        }

        public override ValidationResult Editar(GrupoVeiculos registro)
        {
            var validacaoBanco = FuncionarioForValidoParaEditar(registro);

            if (validacaoBanco.IsValid) return base.Editar(registro);
            else return validacaoBanco;
        }

        public override ValidationResult InserirNovo(GrupoVeiculos registro)
        {
            var validacaoBanco = FuncionarioForValidoParaInserir(registro);
            if (validacaoBanco.IsValid) return base.InserirNovo(registro);
            else return validacaoBanco;
        }
        private ValidationResult FuncionarioForValidoParaEditar(GrupoVeiculos registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioGrupoVeiculos)Repositorio).SelecionarPorNome(registro.NomeGrupo);
            if (func1 != null && func1._id != registro._id) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nome repetido"));

            return valido;
        }
        private ValidationResult FuncionarioForValidoParaInserir(GrupoVeiculos registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioGrupoVeiculos)Repositorio).SelecionarPorNome(registro.NomeGrupo);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nome repetido"));

            return valido;

        }
    }
}
