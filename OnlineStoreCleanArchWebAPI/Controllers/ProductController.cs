using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStoreCleanArchWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddProduct([FromBody] ProductEntity product)
        {
            ProductEntity _ = await sender.Send(new AddProductCommand(product));

            return Ok();
        }

        [HttpPost("/bulkInsert/{StartOffSet}/{NumOfProducts}")]
        public async Task BulkInsertProducts([FromRoute] int StartOffSet, [FromRoute] int NumOfProducts)
        {
            await sender.Send(new BulkInsertProductCommand(StartOffSet, NumOfProducts));
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int Id)
        {
            bool _ = await sender.Send(new DeleteProductCommand(Id));

            return Ok();
        }

        [HttpGet("")]
        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return await sender.Send(new GetAllProductsQuery());
        }

        [HttpGet("/{Id}")]
        public async Task<ProductEntity> GetProductsById([FromRoute] int Id)
        {
            return await sender.Send(new GetProductByIdQuery(Id));
        }

        [HttpPut("update/{Id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int Id, [FromBody] ProductEntity Product)
        {
            bool result = await sender.Send(new UpdateProductCommand(Id, Product));

            return result ? Ok() : NotFound();
        }
    }
}
