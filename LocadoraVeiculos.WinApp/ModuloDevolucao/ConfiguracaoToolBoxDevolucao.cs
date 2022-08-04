using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WinApp.ModuloDevolucao
{
    public class ConfiguracaoToolBoxDevolucao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Devolução";

        public override string TooltipInserir => "";

        public override string TooltipEditar => "Cadastrar Devolução";

        public override string TooltipExcluir => "Remover Devolução";

        public override string TooltipAdicionarItens => "";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar devoluções";

        public override string TooltipPDF => "Gerar PDF";
        public override bool EditarHabilitado => true;
        public override bool InserirHabilitado => false;
        public override bool ExcluirHabilitado => false;
        public override bool BtnPdf => true;

    }
}
