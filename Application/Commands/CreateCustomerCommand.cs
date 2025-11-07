using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands
{
    public record CreateCustomerCommand(CustomerEntity Customer): IRequest<CustomerEntity>;

    public class CreateCustomerCommandHandler(ICustomerRepository CustomerRepository) : IRequestHandler<CreateCustomerCommand, CustomerEntity>
    {
        public async Task<CustomerEntity> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await CustomerRepository.CreateCustomer(request.Customer);
        }
    }
}
