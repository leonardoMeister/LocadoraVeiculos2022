using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ConfiguracaoToolBoxPlanoCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Plano de Cobrança";

        public override string TooltipInserir => "Inserir Plano de Cobrança";

        public override string TooltipEditar => "Editar Plano de Cobrança";

        public override string TooltipExcluir => "Excluir Plano de Cobrança";

        public override string TooltipAdicionarItens => "";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar Plano de Cobrança";

        public override string TooltipAgrupar => "Agrupar Plano de Cobrança";
    }
}
