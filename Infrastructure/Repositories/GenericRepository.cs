﻿using Microsoft.EntityFrameworkCore;
using ShopClothing.Domain.Interface;
using ShopClothing.Infrastructure.Data;


namespace ShopClothing.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext context) : IGeneric<TEntity> where TEntity : class
    {
        public async Task<int> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {

            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity is null)
                return 0;

            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();


        }

        public async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var result = await context.Set<TEntity>().FindAsync(id);
            return result!;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync();

        }

        //public async Task<int> SaveChangesAsync()
        //{
        //    return await context.SaveChangesAsync();
        //}
    }
}
