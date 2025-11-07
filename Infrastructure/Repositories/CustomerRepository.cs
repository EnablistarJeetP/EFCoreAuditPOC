using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository

    {
        public async Task<IEnumerable<CustomerEntity>> GetCustomers()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<CustomerEntity> GetCustomerDetailsById(int id)
        {
            CustomerEntity? product = await context.Customers.Where(product => product.Id == id).FirstOrDefaultAsync();

            return product ?? throw new Exception("Product not found");

        }

        public async Task<CustomerEntity> CreateCustomer(CustomerEntity customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            
            context.Customers.Add(customer);

            await context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            CustomerEntity? customer = await context.Customers.Where(prod => prod.Id == id).FirstOrDefaultAsync();
            if (customer is not null)
            {
                context.Customers.Remove(customer);
                return await context.SaveChangesAsync() > 0;
            }
                

            return false;
        }

        public async Task<bool> UpdateCustomerData(int Id, CustomerEntity customer)
        {
            CustomerEntity? cust = await context.Customers.Where(p => p.Id == Id).FirstOrDefaultAsync();

            if (cust is not null)
            {
                cust.FirstName = customer.FirstName;
                cust.LastName = customer.LastName;
                cust.EmailId = customer.EmailId;
                cust.Gender = customer.Gender;

                context.Customers.Update(cust);

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
