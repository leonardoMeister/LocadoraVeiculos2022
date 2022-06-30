﻿using LocadoraVeiculos.WinApp.shared;
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

        public override string TooltipInserir => "Cadastro de CLientes";

        public override string TooltipEditar => "Edição de clientes";

        public override string TooltipExcluir => "Exclusao de clientes";

        public override string TooltipAdicionarItens => "Adicionar clientes";

        public override string TooltipAtualizarItens => "Atualizar Clientes";

        public override string TooltipFiltrar => "Filtrar clientes";

        public override string TooltipAgrupar => "Agrupar clientes";
    }
}