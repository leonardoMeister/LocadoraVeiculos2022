using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WinApp.ModuloCondutores
{
    internal class ConfiguracaoToolBoxCondutores : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Condutor";

        public override string TooltipInserir => "Inserir de Condutores";

        public override string TooltipEditar => "Editar Condutores";

        public override string TooltipExcluir => "Excluir Condutores";

        public override string TooltipAdicionarItens => "";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar Condutores";

        public override string TooltipAgrupar => "Agrupar Condutores";
    }
}
