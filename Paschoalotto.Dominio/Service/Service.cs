using Paschoalotto.Dominio.Service.Interfaces;
using Paschoalotto.Dominio.Transacoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Dominio.Service
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> SaveChangesAsync() => _unitOfWork.SaveChangesAsync();
    }
}
