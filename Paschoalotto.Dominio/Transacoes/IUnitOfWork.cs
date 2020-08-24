using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Dominio.Transacoes
{
    public interface IUnitOfWork : IDisposable
    {
        bool SaveChanges();

        Task<bool> SaveChangesAsync();
    }
}
