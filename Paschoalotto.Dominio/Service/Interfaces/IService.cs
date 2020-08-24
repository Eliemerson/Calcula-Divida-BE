using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Dominio.Service.Interfaces
{
    public interface IService
    {
        Task<bool> SaveChangesAsync();
    }
}
