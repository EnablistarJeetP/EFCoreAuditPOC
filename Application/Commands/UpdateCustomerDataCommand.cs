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
    public record UpdateCustomerDataCommand(int Id, CustomerEntity Customer) : IRequest<bool>;

    public class UpdateCustomerCommandHandler(ICustomerRepository CustomerRepository) : IRequestHandler<UpdateCustomerDataCommand, bool>
    {
        public async Task<bool> Handle(UpdateCustomerDataCommand request, CancellationToken cancellationToken)
        {
            return await CustomerRepository.UpdateCustomerData(request.Id, request.Customer);
        }
    }
}
