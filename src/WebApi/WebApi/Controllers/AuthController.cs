using Application.Interfaces.Services;
using Application.ViewModels.Request.Auth.Post;
using Microsoft.AspNetCore.Mvc;
using Utils.Interfaces;

namespace WebApi.Controllers
{

    [Route("[controller]")]
    public class AuthController : PrincipalController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService, INotificador notificador) : base(notificador)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(LoginAuthPostRequest request)
        {
            var response = await _authService.LoginAsync(request);
            return CustomResponse(response);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> RegistrarAsync(RegistrarAuthPostRequest request)
        {
            var response = await _authService.RegistrarAsync(request);
            return CustomResponse(response);
        }
    }
}
