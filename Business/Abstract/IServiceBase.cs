using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IServiceBase<TEntity> where TEntity : class, IEntity, new()
    {
        IDataResult<List<TEntity>> GetAll();
        IDataResult<TEntity> GetById(int id);
        IResult Insert(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);

    }
}
