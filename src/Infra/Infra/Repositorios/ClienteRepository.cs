using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class ClienteRepository : CommonRepository, IClienteRepository
    {
        public ClienteRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<bool> AdicionarAsync(Cliente cliente)
        {
            await _dataContext.Clientes.AddAsync(cliente);
            return true;
        }

        public async Task<IEnumerable<Cliente>> ObterAsync()
        {
            var result = await _dataContext.Clientes.Where(x => x.EstaAtivo).ToListAsync();
            return result;
        }

        public async Task<Cliente?> ObterPorId(int id)
        {
            var result = await _dataContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
