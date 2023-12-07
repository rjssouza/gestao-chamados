using Newtonsoft.Json;

namespace Chamados.Application.ViewModels.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioOpcaoViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioOpcaoViewModel()
        {
            Texto = string.Empty;
            ControlType = string.Empty;
            Order = 1;
            IdQuestao = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("controlType")]
        public string ControlType { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<Pair>? DropDownOptions { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("value")]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string IdQuestao { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Key => $"{Id}_{ControlType}_{Order}";

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("controlType")]
        public int Order { get; set; }

        /// <summary>
        ///
        /// </summary>
        public FormularioQuestaoViewModel? ProximaQuestao { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("label")]
        public string Texto { get; set; }
    }
}