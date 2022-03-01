using HCP.DataAccess.Repository;
using System;

namespace HCP.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _dataContext;
        private readonly ProductRepository productRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly CustomAttributeRepository customAttributeRepository;
        private readonly Product_CustomAttribute_MappingRepository product_CustomAttribute_MappingRepository;
        private readonly CustomAttributeOptionRepository customAttributeOptionRepository;

        private bool disposed = false;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public ProductRepository ProductRepository
        {
            get
            {
                return this.productRepository ?? new ProductRepository(_dataContext);
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                return this.categoryRepository ?? new CategoryRepository(_dataContext);
            }
        }

        public CustomAttributeRepository CustomAttributeRepository
        {
            get
            {
                return this.customAttributeRepository ?? new CustomAttributeRepository(_dataContext);
            }
        }

        public CustomAttributeOptionRepository CustomAttributeOptionRepository
        {
            get
            {
                return this.customAttributeOptionRepository ?? new CustomAttributeOptionRepository(_dataContext);
            }
        }

        public Product_CustomAttribute_MappingRepository Product_CustomAttribute_MappingRepository
        {
            get
            {
                return this.product_CustomAttribute_MappingRepository ?? new Product_CustomAttribute_MappingRepository(_dataContext);
            }
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
