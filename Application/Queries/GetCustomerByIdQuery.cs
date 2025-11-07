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
    public record GetCustomerByIdQuery(int Id) : IRequest<CustomerEntity>;

    public class GetCustomerByIdQueryHandler(ICustomerRepository CustomerRepository) : IRequestHandler<GetCustomerByIdQuery, CustomerEntity>
    {
        public async Task<CustomerEntity> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await CustomerRepository.GetCustomerDetailsById(request.Id);
        }
    }
}
