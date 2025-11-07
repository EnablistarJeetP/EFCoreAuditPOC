using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Domain.Interfaces;


using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository

    {
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetProductById(int id)
        {
            ProductEntity? product = await context.Products.Where(product => product.Id == id).FirstOrDefaultAsync();

            return product ?? throw new Exception("Product not found");

        }

        public async Task<ProductEntity> AddProduct(ProductEntity product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            
            context.Products.Add(product);

            await context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            ProductEntity? product = await context.Products.Where(prod => prod.Id == id).FirstOrDefaultAsync();
            if (product is not null)
            {
                context.Products.Remove(product);
                return await context.SaveChangesAsync() > 0;
            }
                

            return false;
        }

        public async Task<bool> UpdateProduct(int Id, ProductEntity Product)
        {
            ProductEntity? prod = await context.Products.Where(p => p.Id == Id).FirstOrDefaultAsync();

            if (prod is not null)
            {
                prod.Name = Product.Name;
                prod.Price = Product.Price;
                prod.Quantity = Product.Quantity;
                prod.Description = Product.Description;

                context.Products.Update(prod);

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
