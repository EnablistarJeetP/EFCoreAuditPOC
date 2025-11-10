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
    public record BulkInsertProductCommand(int StartOffSet, int NumOfProducts): IRequest<Unit>;

    public class BulkInsertProductCommandHandler(IProductRepository productRepository) : IRequestHandler<BulkInsertProductCommand, Unit>
    {
        public async Task<Unit> Handle(BulkInsertProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.BulkInsertProducts(request.StartOffSet, request.NumOfProducts);

            return Unit.Value;
        }
    }
}
