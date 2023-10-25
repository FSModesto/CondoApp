using System.ComponentModel;

namespace Domain.Enums
{
    public enum EMessageType
    {
        Unknown = 0,

        [Description("Reunião")]
        Meeting,

        [Description("Aviso")]
        Warning,

        [Description("Evento")]
        Event,

        [Description("Pagamento")]
        Payment,
    }
}