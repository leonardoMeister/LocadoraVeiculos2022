using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao : ServicoBase<Locacao>
    {
        public ServicoLocacao(RepositorioLocacaoOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }

        protected override AbstractValidator<Locacao> PegarValidador()
        {
            return new ValidadorLocacao();
        }

        protected override ValidationResult RegistroForValidoParaEditarBanco(Locacao registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }

        protected override ValidationResult RegistroForValidoParaInserirBanco(Locacao registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }

    }
}
