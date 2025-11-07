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
    public record UpdateProductCommand(int Id, ProductEntity Product) : IRequest<bool>;

    public class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.UpdateProduct(request.Id, request.Product);
        }
    }
}
