namespace Chamados.Domain.Enum
{
    /// <summary>
    ///
    /// </summary>
    public static class TagBadgeConst
    {
        ///
        public const string Acesso = "warning";

        ///
        public const string CoreShop = "secondary";

        ///
        public const string HPDC = "success";

        ///
        public const string Incidente = "danger";

        ///
        public const string Maquina = "primary";

        ///
        public const string Outros = "light";

        ///
        public const string Relatorios = "info";

        ///
        public const string SPM = "danger";

        ///
        public const string Usinagem = "dark";

        ///
        private static Dictionary<string, string> listaTagBadge = new()
        {
            { "HPDC", TagBadgeConst.HPDC },
            { "Maquina", TagBadgeConst.Maquina },
            { "Incidente", TagBadgeConst.Incidente },
            { "Acesso", TagBadgeConst.Acesso },
            { "Relatorios", TagBadgeConst.Relatorios },
            { "SPM", TagBadgeConst.SPM },
            { "CoreShop", TagBadgeConst.CoreShop },
            { "Usinagem", TagBadgeConst.Usinagem },
            { "Outros", TagBadgeConst.Outros }
        };

        /// <summary>
        ///
        /// </summary>
        public static Dictionary<string, string> ListaTagBadge { get => listaTagBadge; set => listaTagBadge = value; }
    }
}