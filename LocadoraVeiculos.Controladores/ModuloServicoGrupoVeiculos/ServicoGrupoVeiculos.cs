using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using Serilog;

namespace LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos
{
    public class ServicoGrupoVeiculos : Controlador<GrupoVeiculos>
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
            Log.Logger.Debug("Tentando editar um GrupoVeiculos... {@f}", registro);

            var validacaoBanco = GrupoVeiculosForValidoParaEditar(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("GrupoVeiculos {GrupoVeiculosID} editado com sucesso", registro._id);

                return base.Editar(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um GrupoVeiculos {GrupoVeiculosID} - {Motivo}",
                        registro._id, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }

        public override ValidationResult InserirNovo(GrupoVeiculos registro)
        {
            var validacaoBanco = GrupoVeiculosForValidoParaInserir(registro);
            if (validacaoBanco.IsValid)
            {
                Log.Logger.Debug("GrupoVeiculos {GrupoVeiculosID} inserido com sucesso", registro._id);

                return base.InserirNovo(registro);
            }
            else
            {
                foreach (var erros in validacaoBanco.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um GrupoVeiculos {GrupoVeiculosID} - {Motivo}",
                        registro._id, erros.ErrorMessage);
                    return validacaoBanco;
                }
            }

            return validacaoBanco;
        }

        private ValidationResult GrupoVeiculosForValidoParaEditar(GrupoVeiculos registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioGrupoVeiculos)Repositorio).SelecionarPorNome(registro.NomeGrupo);
            if (func1 != null && func1._id != registro._id) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nome repetido"));

            return valido;
        }
        private ValidationResult GrupoVeiculosForValidoParaInserir(GrupoVeiculos registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioGrupoVeiculos)Repositorio).SelecionarPorNome(registro.NomeGrupo);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nome repetido"));

            return valido;

        }
    }
}
