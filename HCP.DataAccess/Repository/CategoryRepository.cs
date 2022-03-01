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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Category> GetByIdAsync(Guid? id)
        {
            if (id.HasValue)
                return null;

            var category = await _dataContext.Categories.FindAsync(id);

            return category;
        }

        public async Task<ICollection<Category>> GetByIdsAsync(ICollection<Guid> ids)
        {
            var categories = await _dataContext.Categories.Where(_ => ids.Contains(_.Id)).ToListAsync();

            return categories;
        }

        public async Task<ICollection<Category>> GetAllAsync(Expression<Func<Category, bool>> expression = null)
        {
            var categories = await _dataContext.Categories.Where(expression).ToListAsync();

            return categories;
        }

        public async Task InsertAsync(Category entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public async Task UpdateAsync(Category entity)
        {
            var category = await _dataContext.Categories.FindAsync(entity.Id);

            category.Name = entity.Name;
        }

        public async Task DeleteAsync(Category entity)
        {
            _dataContext.Remove(entity);
        }
    }
}
