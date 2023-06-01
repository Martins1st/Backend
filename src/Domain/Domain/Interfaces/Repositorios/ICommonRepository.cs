using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositorios
{
    public interface ICommonRepository
    {
        public bool RastrearEntidade(CommonEntity entidade);
    }
}
