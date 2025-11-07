using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries
{
    public record GetAllCustomersQuery() : IRequest<IEnumerable<CustomerEntity>>;

    public class GetAllCustomersQueryHandler(ICustomerRepository productRepository) : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerEntity>>
    {
        public async Task<IEnumerable<CustomerEntity>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetCustomers();
        }
    }
}
