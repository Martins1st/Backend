using Application.ViewModels.Request.Cliente.Post;
using Application.ViewModels.Request.Cliente.Put;
using Application.ViewModels.Response.Cliente.Get;

namespace Application.Interfaces.Services
{
    public interface IClienteService
    {
        public Task<bool> AdicionarAsync(ClientePostRequest request);
        public Task<IEnumerable<ClienteGetResponse>> BuscarAsync();
        public Task<bool> DesativarAsync(int id);

        public Task<bool> AtualizarAsync(ClientePutRequest request);
        public Task<ClienteGetResponse> ObterPorIdAsync(int id);
    }
}
