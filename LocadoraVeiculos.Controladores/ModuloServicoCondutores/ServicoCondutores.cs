using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloCondutores;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoCondutores
{
    public class ServicoCondutores : ServicoBase<Condutores>
    {
        public ServicoCondutores(RepositorioCondutorOrm repo, IContextoPersistencia contexto) : base(repo,contexto)
        {

        }

        protected override AbstractValidator<Condutores> PegarValidador()
        {
            return new ValidadorCondutores();
        }

        protected override ValidationResult RegistroForValidoParaEditarBanco(Condutores registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }

        protected override ValidationResult RegistroForValidoParaInserirBanco(Condutores registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }
    }
}
