using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Dominio.Repositorios.Interfaces
{
    public interface IRepositorio<T> : IDisposable
    {
        T Salvar(T entity);
        Task<T> ObterPorId(int id);
        IQueryable<T> NoTracking();
    }
}
