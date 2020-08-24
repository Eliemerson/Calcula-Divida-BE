using Microsoft.EntityFrameworkCore;
using Paschoalotto.Dominio.Transacoes;
using Paschoalotto.Repositorio.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Repositorio.Database.Transacoes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaschoalottoContext _context;

        public UnitOfWork(PaschoalottoContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
