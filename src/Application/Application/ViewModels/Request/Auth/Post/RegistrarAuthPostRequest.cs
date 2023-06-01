
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Request.Auth.Post
{
    public class RegistrarAuthPostRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmarSenha { get; set; }
    }
}
