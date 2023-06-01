
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Request.Auth.Post
{
    public class LoginAuthPostRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}
