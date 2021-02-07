using Deezefy.Business.Interfaces;
using Deezefy.Business.Models;
using Deezefy.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Deezefy.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DeezefyDbContext DbContext;

        protected readonly DbSet<T> DbSet;
        public Repository(DeezefyDbContext dbContext)
        {
            DbContext = dbContext;

            DbSet = dbContext.Set<T>();
        }   
        public async Task Adicionar(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await SaveChanges();
                
        }

        public async Task Atualizar(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<ICollection<T>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ICollection<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }


        public async Task<int> SaveChanges()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

    }
}
