namespace Chamados.Application.ViewModels.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioOpcaoDropDownViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public IEnumerable<Pair>? Opcoes { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class Pair
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Pair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        ///
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Value { get; set; }
    }
}