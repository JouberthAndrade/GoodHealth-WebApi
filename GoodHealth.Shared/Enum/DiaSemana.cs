using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GoodHealth.Shared.Enum
{
    public enum DiaSemana
    {
        [Description("SG")]
        ConsultasExames = 1,
        [Description("TE")]
        Retorno = 2,
        [Description("QA")]
        Sessao = 3,
        [Description("QI")]
        Quinta = 4,
        [Description("SX")]
        Sexta = 5,
        [Description("SA")]
        Sabado = 6,
        [Description("DM")]
        Domingo = 0
    }
}
