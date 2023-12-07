namespace Auth.Application.Interfaces
{
    public interface IUserPhotoAppService : IDisposable
    {
        Task<byte[]> ObterFotoUsuario(string userName);
    }
}