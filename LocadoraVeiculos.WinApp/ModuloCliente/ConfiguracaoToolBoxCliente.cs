using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    internal class ConfiguracaoToolBoxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cliente";

        public override string TooltipInserir => "Inserir CLientes";

        public override string TooltipEditar => "Editar clientes";

        public override string TooltipExcluir => "Excluir clientes";

        public override string TooltipAdicionarItens => "";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "Filtrar clientes";

        public override string TooltipAgrupar => "Agrupar clientes";
    }
}
