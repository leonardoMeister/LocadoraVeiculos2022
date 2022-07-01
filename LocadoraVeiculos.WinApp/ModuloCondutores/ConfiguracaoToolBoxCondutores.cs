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

        public override string TooltipInserir => "Cadastro de Condutores";

        public override string TooltipEditar => "Edição de Condutores";

        public override string TooltipExcluir => "Exclusao de Condutores";

        public override string TooltipAdicionarItens => "Adicionar Condutores";

        public override string TooltipAtualizarItens => "Atualizar Condutores";

        public override string TooltipFiltrar => "Filtrar Condutores";

        public override string TooltipAgrupar => "Agrupar Condutores";
    }
}
