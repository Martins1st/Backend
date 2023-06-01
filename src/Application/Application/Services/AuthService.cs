using Application.Interfaces.Services;
using Application.ViewModels.Request.Auth.Post;
using Application.ViewModels.Response.Auth.Post;
using System.Net;
using Utils.Interfaces;
using System.Security.Claims;
using System.Text;
using Utils.Models;
using Application.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly INotificador _notificador;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;


        public AuthService(INotificador notificador,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings
                              )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _notificador = notificador;
        }

        public async Task<AuthPostResponse> LoginAsync(LoginAuthPostRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Login, request.Senha, false, true);
            if (!result.Succeeded)
            {
                _notificador.Handle(new Notificacao("Usuario ou Senha Incorreto", HttpStatusCode.NotFound));
                return null;
            }
            if (result.IsLockedOut)
            {
                _notificador.Handle(new Notificacao("Usuario temporariamente bloqueado por tentativas inválidas"));
                return null;
            }


            var user = await _userManager.FindByNameAsync(request.Login);
            var token = await GerarJwt(user);
            
            var payload = new AuthPostResponse
            {
                Token = token
            };


            return payload;
        }

        public async Task<bool> RegistrarAsync(RegistrarAuthPostRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.Login,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Senha);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _notificador.Handle(new Notificacao(error.Description));
                }
                return false;
            }

            await _signInManager.SignInAsync(user, false);

            return true;
        }


        private async Task<string> GerarJwt(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        
    }
}
