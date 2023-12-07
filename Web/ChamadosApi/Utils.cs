using Microsoft.AspNetCore.StaticFiles;

namespace ChamadosApi
{
    /// <summary>
    /// Utils
    /// </summary>
    public static class Utils
    {
        /// <summary>
        ///
        /// </summary>
        public static string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out string? contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}