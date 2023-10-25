using System.ComponentModel;

namespace Domain.Enums
{
    public enum EUserType
    {
        Unknown = 0,

        [Description("Síndico")]
        Syndic,

        [Description("Morador")]
        Resident
    }
}
