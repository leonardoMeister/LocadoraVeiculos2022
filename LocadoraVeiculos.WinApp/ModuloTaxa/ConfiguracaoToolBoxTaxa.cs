using LocadoraVeiculos.WinApp.shared;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    internal class ConfiguracaoToolBoxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Taxas";

        public override string TooltipInserir => "Inserir Taxa";

        public override string TooltipEditar => "Editar Taxa";

        public override string TooltipExcluir => "Excluir Taxa";

        public override string TooltipAdicionarItens => "";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar Taxa";

        public override string TooltipPDF => "Agrupar Taxa";
    }
}
