using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.DirectoryServices;
using System.Reflection;

namespace Auth.Utils
{
    public class AdUserFactory
    {
        public const string P_COUNTRY = "co";
        public const string P_EMAIL = "mail";
        public const string P_FOTO = "jpegPhoto";
        public const string P_LOCALITY = "streetaddress";
        public const string P_NOME = "givenName";
        public const string P_PHONE = "telephonenumber";
        public const string P_POSTALCODE = "postalcode";
        public const string P_SOBRENOME = "sn";
        public const string P_STATE = "st";
        public const string P_TITLE = "description";
        public const string P_USERNAME = "sAMAccountName";
        public const string P_USERPRINCIPALNAME = "userprincipalname";
        private const string DOMINIO = "LDAP://bradcs0003.am.nemak.net";
        private const string LOGIN_MASTER = "am-bra-syng-svc";
        private const string SENHA_MASTER = "S1ng-N3m4k@2020";
        private readonly ILogger<AdUserFactory> _logger;
        private readonly DirectoryEntry _oAd;

        public AdUserFactory(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetRequiredService<ILogger<AdUserFactory>>();
            _oAd = new DirectoryEntry(DOMINIO, LOGIN_MASTER, SENHA_MASTER);
        }

        /// <summary>
        /// ///
        /// </summary>
        /// <param name="dominioUserName"></param>
        /// <returns></returns>
        public SearchResult? ObterDadosUsuario(string? userName)
        {
            try
            {
                _logger.LogInformation("FACTORY User com login: {domainName}", userName);

                if (string.IsNullOrWhiteSpace(userName))
                    return null;

                var directorySearcher = new DirectorySearcher(_oAd, $"(&(objectClass=user)(sAMAccountName={userName.ToLower()}))");
                var user = directorySearcher.FindOne();
                _logger.LogInformation("User AD info {user}", JsonConvert.SerializeObject(user));

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("FACTORY User com login: {domainName}, erro: {exceptionMessage}", userName, ex.Message);

                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dominioUserName"></param>
        /// <returns></returns>
        public byte[] ObterFotoUsuario(string? userName)
        {
            string strExeFilePath = Assembly.GetExecutingAssembly().Location;
            string strWorkPath = Path.GetDirectoryName(strExeFilePath) ?? throw new ArgumentNullException(nameof(userName));
            string defaultPhotoPath = $"{strWorkPath}/Contents/AvatarUsuario/default-user.png";
            MemoryStream memoryStream = new();
            Image.LoadAsync(defaultPhotoPath).Result.Save(memoryStream, SixLabors.ImageSharp.Formats.Png.PngFormat.Instance);

            var usuarioAD = ObterDadosUsuario(userName);
            if (usuarioAD == null || !usuarioAD.Properties.Contains(P_FOTO))
                return memoryStream.ToArray();

            var property = usuarioAD.Properties[P_FOTO];
            if (property.Count <= 0)
                return memoryStream.ToArray();

            if (property[0] is not byte[] dataPhoto)
                return memoryStream.ToArray();

            return dataPhoto;
        }
    }
}