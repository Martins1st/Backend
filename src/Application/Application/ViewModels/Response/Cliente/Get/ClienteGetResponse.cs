namespace Application.ViewModels.Response.Cliente.Get
{
    public class ClienteGetResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public double OrcamentoInicial { get; set; }
    }
}
