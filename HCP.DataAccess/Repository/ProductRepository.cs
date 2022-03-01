using HCP.Core.Domain;
using HCP.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HCP.Core.Extensions;

namespace HCP.DataAccess
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Product> GetByIdAsync(Guid? id)
        {
            if (id.HasValue)
                return null;

            var product = await _dataContext.Products.FindAsync(id);

            return product;
        }

        public async Task<ICollection<Product>> GetByIdsAsync(ICollection<Guid> ids)
        {
            var products = await _dataContext.Products.Where(_ => ids.Contains(_.Id)).ToListAsync();

            return products;
        }

        public async Task<ICollection<Product>> GetAllAsync(Expression<Func<Product, bool>> expression = null)
        {
            var products = await _dataContext.Products.Where(expression).ToListAsync();

            return products;
        }

        public async Task InsertAsync(Product entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            var product = await _dataContext.Products.FindAsync(entity.Id);

            product.Name = entity.Name;
            product.Url = entity.Url;
            product.Price = entity.Price;
            product.Description = entity.Description;
            product.CategoryId = entity.CategoryId;
        }

        public async Task DeleteAsync(Product entity)
        {
            _dataContext.Remove(entity);
        }
    }
}
