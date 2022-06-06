using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AH_Project.Models.Helper;
using AH_Project.Models.Services.Interfaces;

namespace AH_Project.Models.Services.Services
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }        
        public async Task<T?> GetByIdAsync(int id)
        {           
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T?> FindAsync(Expression<Func<T, bool>> filter, string[]? includes = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                    foreach (var incluse in includes)
                        query = query.Include(incluse);

                return await query.SingleOrDefaultAsync(filter);
            }
            else
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                    foreach (var incluse in includes)
                        query = query.Include(incluse);

                return await query.AsNoTracking().SingleOrDefaultAsync(filter);
            }               
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, string[]? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(filter).ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, int? take, int? skip, string[]? includes = null,
            Expression<Func<T, object>>? orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(filter);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return true;
            }
            return false;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AttachRange(entities);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().CountAsync(filter);
        }
    }

}
