using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Request.Cliente.Put
{
    public class ClientePutRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double OrcamentoInicial { get; set; }
    }
}
