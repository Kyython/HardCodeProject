using HCP.Core.Domain;
using HCP.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HCP.Core.Extensions;

namespace HCP.DataAccess.Repository
{
    public class CustomAttributeRepository : IRepository<CustomAttribute>
    {
        private readonly DataContext _dataContext;

        public CustomAttributeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CustomAttribute> GetByIdAsync(Guid? id)
        {
            if (id.HasValue)
                return null;

            var customAttribute = await _dataContext.CustomAttributes.FindAsync(id);

            return customAttribute;
        }

        public async Task<ICollection<CustomAttribute>> GetByIdsAsync(ICollection<Guid> ids)
        {
            var customAttributes = await _dataContext.CustomAttributes.Where(_ => ids.Contains(_.Id)).ToListAsync();

            return customAttributes;
        }

        public async Task<ICollection<CustomAttribute>> GetAllAsync(Expression<Func<CustomAttribute, bool>> expression = null)
        {
            var customAttributes = await _dataContext.CustomAttributes.Where(expression).ToListAsync();

            return customAttributes;
        }

        public async Task InsertAsync(CustomAttribute entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public async Task UpdateAsync(CustomAttribute entity)
        {
            var customAttribute = await _dataContext.CustomAttributes.FindAsync(entity.Id);

            customAttribute.Name = entity.Name;
            customAttribute.CategoryId = entity.CategoryId;
        }

        public async Task DeleteAsync(CustomAttribute entity)
        {
            _dataContext.Remove(entity);
        }
    }
}
