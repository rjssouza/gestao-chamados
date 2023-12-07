using System.ComponentModel;

namespace Chamados.Domain.Enum
{
    /// <summary>
    ///
    /// </summary>
    public enum TipoEnum
    {
        ///
        [Description("radiobutton")]
        RadioButton = 1,

        ///
        [Description("textbox")]
        TextBox = 2,

        ///
        [Description("dropdown")]
        DropDown = 3,

        ///
        [Description("textarea")]
        TextArea = 4,
    }
}