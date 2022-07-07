using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public class ConfiguracaoToolBoxGrupoVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Grupo Veiculos";

        public override string TooltipInserir => "Inserir Grupo Veiculos";

        public override string TooltipEditar => "Editar Grupo Veiculos";

        public override string TooltipExcluir => "Excluir Grupo Veiculos";

        public override string TooltipAdicionarItens => "";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar Grupo Veiculos";

        public override string TooltipAgrupar => "Agrupar Grupo Veiculos";
    }
}
