using Auth.Application.Interfaces;
using Auth.Utils;
using Core.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Application.ServiceApps
{
    /// <summary>
    ///
    /// </summary>
    internal class UserPhotoAppService : ServiceApp, IUserPhotoAppService
    {
        private readonly AdUserFactory _adUserFactory;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        public UserPhotoAppService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _adUserFactory = serviceProvider.GetRequiredService<AdUserFactory>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public Task<byte[]> ObterFotoUsuario(string userName)
        {
            var imagemUser = _adUserFactory.ObterFotoUsuario(userName);

            return Task.FromResult(imagemUser);
        }
    }
}