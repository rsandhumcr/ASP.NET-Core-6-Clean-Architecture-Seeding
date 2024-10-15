﻿using Microsoft.EntityFrameworkCore;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;

namespace CompanyNameSpace.ProjectName.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ProjectNameDbContext DbContext;

        public BaseRepository(ProjectNameDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            T? t = await DbContext.Set<T>().FindAsync(id);
            return t;
        }

        public virtual async Task<T?> GetByIntIdAsync(int id)
        {
            T? t = await DbContext.Set<T>().FindAsync(id);
            return t;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size)
        {
            return await DbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}