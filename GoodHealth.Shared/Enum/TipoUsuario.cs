using System.ComponentModel;

namespace GoodHealth.Shared.Enum
{
    public enum TipoUsuario
    {
        [Description("admin")]
        Administrador = 1,
        [Description("user")]
        Usuario = 2,
    }
}
