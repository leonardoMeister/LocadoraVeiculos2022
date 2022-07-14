using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloPlanoCobranca;
using Serilog;

namespace LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca>
    {
        protected override IRepository<PlanoCobranca> PegarRepositorio()
        {
            return new RepositorioPlanoCobranca(new MapeadorPlanoCobranca());
        }

        protected override AbstractValidator<PlanoCobranca> PegarValidador()
        {
            return new ValidadorPlanoCobranca();
        }
        public override ValidationResult InserirNovo(PlanoCobranca registro)
        {
            Log.Logger.Debug("PlanoCobranca {PlanoCobrancaID} editado com sucesso", registro._id);

            return base.InserirNovo(registro);
        }

        public override ValidationResult Editar(PlanoCobranca registro)
        {
            Log.Logger.Debug("PlanoCobranca {PlanoCobrancaID} editado com sucesso", registro._id);

            return base.Editar(registro);
        }
    }
}
