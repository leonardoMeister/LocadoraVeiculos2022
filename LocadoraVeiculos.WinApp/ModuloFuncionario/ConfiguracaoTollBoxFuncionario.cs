using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WinApp.ModuloFuncionario
{
    public class ConfiguracaoTollBoxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Funcionario";

        public override string TooltipInserir => "Inserir Funcionário";

        public override string TooltipEditar => "Editar Funcionário";

        public override string TooltipExcluir => "Excluir Funcionário";

        public override string TooltipAdicionarItens =>"";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar Funcionário";

        public override string TooltipAgrupar => "Agrupar Funcionário";
    }
}
