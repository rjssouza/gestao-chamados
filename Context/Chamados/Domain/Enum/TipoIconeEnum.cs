namespace Chamados.Domain.Enum
{
    /// <summary>
    ///
    /// </summary>
    public static class TipoIconeEnum
    {
        ///
        private const string BAT = "codefile";

        ///
        private const string CS = "codefile";

        ///
        private const string DLL = "codefile";

        ///
        private const string DOC = "doc";

        ///
        private const string DOCX = "doc";

        ///
        private const string EXE = "codefile";

        ///
        private const string FILE = "file";

        ///
        private const string GIF = "image";

        ///
        private const string HTML = "html";

        ///
        private const string JPEG = "image";

        ///
        private const string JPG = "image";

        ///
        private const string JS = "codefile";

        ///
        private const string JSON = "codefile";

        ///
        private const string M4A = "audio";

        ///
        private const string MKV = "video";

        ///
        private const string MP3 = "audio";

        ///
        private const string MP4 = "video";

        ///
        private const string MPG = "video";

        ///
        private const string PDF = "pdf";

        ///
        private const string PNG = "image";

        ///
        private const string RAR = "zip";

        ///
        private const string TAR = "zip";

        ///
        private const string TEXT_HTML = "html";

        ///
        private const string WMV = "audio";

        ///
        private const string XLS = "xls";

        ///
        private const string XLSX = "xls";

        ///
        private const string XML = "codefile";

        ///
        private const string ZIP = "zip";

        ///
        private static Dictionary<string, string> listaIcone = new()
        {
            { "doc", Doc },
            { "docx", Docx},
            { "xls", Xls},
            { "xlsx", Xlsx},
            { "png", Png},
            { "jpg", Jpg},
            { "jpeg", Jpeg},
            { "file", File},
            { "pdf", Pdf},
            { "mp4", Mp4},
            { "m4a", M4a},
            { "mp3", Mp3},
            { "wmv", Wmv},
            { "zip", Zip},
            { "rar", Rar},
            { "tar", Tar},
            { "exe", Exe},
            { "dll", Dll},
            { "cs", Cs},
            { "js", Js},
            { "xml", Xml},
            { "json", Json},
            { "bat", Bat},
            { "mkv", Mkv},
            { "mpg", Mpg},
            { "gif", Gif},
            { "html", Html},
            { "texthtml", TextHtml},
        };

        /// <summary>
        ///
        /// </summary>
        public static string Bat => BAT;

        /// <summary>
        ///
        /// </summary>
        public static string Cs => CS;

        /// <summary>
        ///
        /// </summary>
        public static string Dll => DLL;

        /// <summary>
        ///
        /// </summary>
        public static string Doc => DOC;

        /// <summary>
        ///
        /// </summary>
        public static string Docx => DOCX;

        /// <summary>
        ///
        /// </summary>
        public static string Exe => EXE;

        /// <summary>
        ///
        /// </summary>
        public static string File => FILE;

        /// <summary>
        ///
        /// </summary>
        public static string Gif => GIF;

        /// <summary>
        ///
        /// </summary>
        public static string Html => HTML;

        /// <summary>
        ///
        /// </summary>
        public static string Jpeg => JPEG;

        /// <summary>
        ///
        /// </summary>
        public static string Jpg => JPG;

        /// <summary>
        ///
        /// </summary>
        public static string Js => JS;

        /// <summary>
        ///
        /// </summary>
        public static string Json => JSON;

        /// <summary>
        ///
        /// </summary>
        public static Dictionary<string, string> ListaIcone { get => listaIcone; set => listaIcone = value; }

        /// <summary>
        ///
        /// </summary>
        public static string M4a => M4A;

        /// <summary>
        ///
        /// </summary>
        public static string Mkv => MKV;

        /// <summary>
        ///
        /// </summary>
        public static string Mp3 => MP3;

        /// <summary>
        ///
        /// </summary>
        public static string Mp4 => MP4;

        /// <summary>
        ///
        /// </summary>
        public static string Mpg => MPG;

        /// <summary>
        ///
        /// </summary>
        public static string Pdf => PDF;

        /// <summary>
        ///
        /// </summary>
        public static string Png => PNG;

        /// <summary>
        ///
        /// </summary>
        public static string Rar => RAR;

        /// <summary>
        ///
        /// </summary>
        public static string Tar => TAR;

        /// <summary>
        ///
        /// </summary>
        public static string TextHtml => TEXT_HTML;

        /// <summary>
        ///
        /// </summary>
        public static string Wmv => WMV;

        /// <summary>
        ///
        /// </summary>
        public static string Xls => XLS;

        /// <summary>
        ///
        /// </summary>
        public static string Xlsx => XLSX;

        /// <summary>
        ///
        /// </summary>
        public static string Xml => XML;

        /// <summary>
        ///
        /// </summary>
        public static string Zip => ZIP;
    }
}