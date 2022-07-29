using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WinApp.ModuloLocacao
{
    internal class ConfiguracaoToolBoxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Locação";

        public override string TooltipInserir => "Inserir Locações";

        public override string TooltipEditar => "Editar Locações";

        public override string TooltipExcluir => "Excluir Locações";

        public override string TooltipAdicionarItens => "";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar Locações";

        public override string TooltipPDF => "Gerar PDF Locações";
    }
}
