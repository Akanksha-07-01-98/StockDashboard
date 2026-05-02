using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;
        public GenericDataService(SimpleTraderDbContextFactory simpleTraderDbContextFactory)
        {
            _contextFactory = simpleTraderDbContextFactory;
        }
        public async Task<T> Create(T entity)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdEntity =await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                context.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
           using(SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                T enitiy = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                return enitiy;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Set<T>().ToListAsync<T>();
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using(SimpleTraderDbContext  context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
