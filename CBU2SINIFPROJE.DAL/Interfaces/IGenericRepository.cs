﻿using System.Collections.Generic;

using CBU2SINIFPROJE.Core.Entities.Interfaces;

namespace CBU2SINIFPROJE.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity: class ,IEntityBase,new() 
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
