
using Domain.Entidades;

namespace Domain.Interfaces.Repositorios
{
    public interface IClienteRepository : ICommonRepository
    {
        public Task<IEnumerable<Cliente>> ObterAsync();
        public Task<Cliente?> ObterPorId(int id);
        public Task<bool> AdicionarAsync(Cliente cliente);

    }
}
