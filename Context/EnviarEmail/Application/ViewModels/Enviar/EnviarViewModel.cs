namespace EnviarEmail.Application.ViewModels.Enviar
{
    /// <summary>
    ///
    /// </summary>
    public class EnviarViewModel
    {
        /// <summary>
        /// Dados no formato Base64
        /// </summary>
        /// <value></value>
        public string? Anexo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public List<string>? Cc { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Corpo { get; set; } = "Seu chamado foi criado com sucesso";

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? NomeAmigavel { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public List<string>? Para { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Titulo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsuarioAtual { get; set; }
    }
}