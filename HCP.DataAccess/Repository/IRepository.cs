using HCP.Core;
using HCP.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HCP.DataAccess
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid? id);

        Task<ICollection<TEntity>> GetByIdsAsync(ICollection<Guid> ids);

        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
