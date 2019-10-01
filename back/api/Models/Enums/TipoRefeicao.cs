using System.ComponentModel;

namespace api.Models.Enums
{
    public enum TipoRefeicao
    {
        [Description("Nenhum")]
        NENHUM = 0,
        [Description("Café da manhã")]
        CAFE_DA_MANHA = 1,
        [Description("Almoço")]
        ALMOCO = 2,
        [Description("Jantar")]
        JANTAR = 3
    }
}
