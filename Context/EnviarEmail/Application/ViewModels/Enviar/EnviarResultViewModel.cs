namespace EnviarEmail.Application.ViewModels.Enviar
{
    /// <summary>
    ///
    /// </summary>
    public class EnviarResultDataViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<EnviarResultViewModel>? Result { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class EnviarResultViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>

        public string? Mensagem { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Result { get; set; }
    }
}