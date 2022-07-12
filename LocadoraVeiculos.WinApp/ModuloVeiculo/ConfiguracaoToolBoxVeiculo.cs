using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public class ConfiguracaoToolBoxVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Veiculo";

        public override string TooltipInserir => "Inserir Veiculos";

        public override string TooltipEditar => "Editar Veiculos";

        public override string TooltipExcluir => "Excluir Veiculos";

        public override string TooltipAdicionarItens => "";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar Veiculos";

        public override string TooltipAgrupar => "Agrupar Veiculos";
    }
}
