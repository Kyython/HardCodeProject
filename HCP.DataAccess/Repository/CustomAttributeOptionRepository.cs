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
    public class CustomAttributeOptionRepository : IRepository<CustomAttributeOption>
    {
        private readonly DataContext _dataContext;

        public CustomAttributeOptionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CustomAttributeOption> GetByIdAsync(Guid? id)
        {
            if (id.HasValue)
                return null;

            var customAttributeOption = await _dataContext.CustomAttributeOptions.FindAsync(id);

            return customAttributeOption;
        }

        public async Task<ICollection<CustomAttributeOption>> GetByIdsAsync(ICollection<Guid> ids)
        {
            var customAttributeOptions = await _dataContext.CustomAttributeOptions.Where(_ => ids.Contains(_.Id)).ToListAsync();

            return customAttributeOptions;
        }

        public async Task<ICollection<CustomAttributeOption>> GetAllAsync(Expression<Func<CustomAttributeOption, bool>> expression = null)
        {
            var customAttributeOptions = await _dataContext.CustomAttributeOptions.Where(expression).ToListAsync();

            return customAttributeOptions;
        }

        public async Task InsertAsync(CustomAttributeOption entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public async Task UpdateAsync(CustomAttributeOption entity)
        {
            var customAttributeOption = await _dataContext.CustomAttributeOptions.FindAsync(entity.Id);

            customAttributeOption.Name = entity.Name;
            customAttributeOption.CustomAttributeId = entity.CustomAttributeId;
        }

        public async Task DeleteAsync(CustomAttributeOption entity)
        {
            _dataContext.Remove(entity);
        }
    }
}
