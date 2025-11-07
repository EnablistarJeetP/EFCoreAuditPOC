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
    public record DeleteCustomerCommand(int Id) : IRequest<bool>;

    public class DeleteCustomerCommandHandler(ICustomerRepository CustomerRepository) : IRequestHandler<DeleteCustomerCommand, bool>
    {
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await CustomerRepository.DeleteCustomer(request.Id);
        }
    }
}
