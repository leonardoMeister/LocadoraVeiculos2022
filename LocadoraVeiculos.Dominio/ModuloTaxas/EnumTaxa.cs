﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloTaxas
{
    public enum EnumTaxa
    {
        [Description("Fixa")]
        Fixa,

        [Description("Diaria")]
        Diaria,
    }
}
