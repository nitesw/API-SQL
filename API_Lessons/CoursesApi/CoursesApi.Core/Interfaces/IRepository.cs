﻿using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task Save();

        Task<IEnumerable<IEntity>> GetAll();
        Task<IEntity?> Get(object id);

        Task Insert(TEntity entity);

        Task Delete(object id);
        Task Delete(TEntity entityToDelete);

        Task Update(TEntity entity);

        Task<TEntity?> GetItemBySpec(ISpecification<TEntity> specification);
        Task<IEnumerable<TEntity>?> GetListBySpec(ISpecification<TEntity> specification);
    }
}
