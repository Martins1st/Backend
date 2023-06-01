
using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Infra.Context;

namespace Infra.Repositorios
{
    public class CommonRepository : ICommonRepository
    {
        protected readonly DataContext _dataContext;
        public CommonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool RastrearEntidade(CommonEntity entidade)
        {
            _dataContext.Attach(entidade);
            return true;
        }
    }
}
