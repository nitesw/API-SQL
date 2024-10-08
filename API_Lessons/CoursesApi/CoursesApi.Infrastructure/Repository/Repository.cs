﻿using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CoursesApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Infrastructure.Repository
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        internal required AppDbContext context;
        internal required DbSet<TEntity> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async virtual Task Delete(object id)
        {
            TEntity? entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                await Delete(entityToDelete);
            }
        }

        public async Task Delete(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            });
        }

        public async Task<IEntity?> Get(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<IEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetItemBySpec(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>?> GetListBySpec(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(dbSet, specification);
        }

        public async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async virtual Task Update(TEntity entity)
        {
            await Task.Run(() =>
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            });
        }
    }
}
