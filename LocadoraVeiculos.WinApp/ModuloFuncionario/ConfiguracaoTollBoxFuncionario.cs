﻿using LocadoraVeiculos.WinApp.shared;
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

        public override string TooltipInserir => "";

        public override string TooltipEditar => "";

        public override string TooltipExcluir => "";

        public override string TooltipAdicionarItens =>"";

        public override string TooltipAtualizarItens => "";

        public override string TooltipFiltrar => "";

        public override string TooltipAgrupar => "";
    }
}