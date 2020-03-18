using System.ComponentModel;

namespace GoodHealth.Shared.Enum
{
    public enum DiaSemana
    {
        [Description("SG")]
        Segunda = 1,
        [Description("TE")]
        Terca = 2,
        [Description("QA")]
        Quarta = 3,
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
