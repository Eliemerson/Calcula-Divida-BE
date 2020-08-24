using Microsoft.EntityFrameworkCore;
using Paschoalotto.Dominio.Entidade;
using Paschoalotto.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Repositorio.Database.Repositorios
{
    public class RepositorioBase<T> : IRepositorio<T> where T : Entity
    {
        public readonly DbContext Context;
        public readonly DbSet<T> DbSet;

        public RepositorioBase(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual T Salvar(T entity)
        {
            if (entity.IsNew)
                DbSet.Add(entity);
            else
                DbSet.Update(entity);

            return entity;
        }

        public virtual async Task<T> ObterPorId(int id) =>
            await NoTracking().FirstOrDefaultAsync(x => x.Id == id);


        public virtual IQueryable<T> NoTracking()
        {
            return DbSet.AsNoTracking();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
