using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductEntity>> GetProducts();

        public Task<ProductEntity> GetProductById(int id);

        public Task<ProductEntity> AddProduct(ProductEntity product);

        public Task<bool> DeleteProduct(int id);

        public Task<bool> UpdateProduct(int Id, ProductEntity product);
    }
}
