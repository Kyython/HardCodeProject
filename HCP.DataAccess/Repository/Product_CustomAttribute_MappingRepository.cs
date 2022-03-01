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
    public class Product_CustomAttribute_MappingRepository : IRepository<Product_CustomAttribute_Mapping>
    {
        private readonly DataContext _dataContext;

        public Product_CustomAttribute_MappingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Product_CustomAttribute_Mapping> GetByIdAsync(Guid? id)
        {
            if (id.HasValue)
                return null;

            var mapping = await _dataContext.Product_CustomAttribute_Mappings.FindAsync(id);

            return mapping;
        }

        public async Task<ICollection<Product_CustomAttribute_Mapping>> GetByIdsAsync(ICollection<Guid> ids)
        {
            var mappings = await _dataContext.Product_CustomAttribute_Mappings.Where(_ => ids.Contains(_.Id)).ToListAsync();

            return mappings;
        }

        public async Task<ICollection<Product_CustomAttribute_Mapping>> GetAllAsync(Expression<Func<Product_CustomAttribute_Mapping, bool>> expression = null)
        {
            var mappings = await _dataContext.Product_CustomAttribute_Mappings.Where(expression).ToListAsync();

            return mappings;
        }

        public async Task InsertAsync(Product_CustomAttribute_Mapping entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public async Task UpdateAsync(Product_CustomAttribute_Mapping entity)
        {
            var mapping = await _dataContext.Product_CustomAttribute_Mappings.FindAsync(entity.Id);

            mapping.CustomAttributeOptionId = entity.CustomAttributeOptionId;
            mapping.ProductId = entity.ProductId;
        }

        public async Task DeleteAsync(Product_CustomAttribute_Mapping entity)
        {
            _dataContext.Remove(entity);
        }
    }
}
