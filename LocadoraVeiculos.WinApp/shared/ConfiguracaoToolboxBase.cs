namespace LocadoraVeiculos.WinApp.shared
{
    public abstract class ConfiguracaoToolboxBase
    {
        public abstract string TipoCadastro { get; }

        public abstract string TooltipInserir { get; }

        public abstract string TooltipEditar { get; }

        public abstract string TooltipExcluir { get; }

        public abstract string TooltipAdicionarItens { get; }

        public abstract string TooltipAtualizarItens { get; }

        public abstract string TooltipFiltrar { get; }

        public abstract string TooltipPDF { get; }


        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool AdicionarItensHabilitado { get { return false; } }

        public virtual bool AtualizarItensHabilitado { get { return false; } }

        public virtual bool FiltrarHabilitado { get { return false; } }

        public virtual bool AgruparHabilitado { get { return false; } }
        public virtual bool BtnPdf { get { return false; } } 

    }
}