
using Application.ViewModels.Request.Auth.Post;
using Application.ViewModels.Response.Auth.Post;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<AuthPostResponse> LoginAsync(LoginAuthPostRequest request);

        public Task<bool> RegistrarAsync(RegistrarAuthPostRequest request);
    }
}
