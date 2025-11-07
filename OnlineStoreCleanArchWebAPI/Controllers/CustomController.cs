using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStoreCleanArchWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerEntity Customer)
        {
            CustomerEntity _ = await sender.Send(new CreateCustomerCommand(Customer));

            return Ok();
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int Id)
        {
            bool _ = await sender.Send(new DeleteCustomerCommand(Id));

            return Ok();
        }

        [HttpGet("")]
        public async Task<IEnumerable<CustomerEntity>> GetAllCustomers()
        {
            return await sender.Send(new GetAllCustomersQuery());
        }

        [HttpGet("/{Id}")]
        public async Task<CustomerEntity> GetCustomersById([FromRoute] int Id)
        {
            return await sender.Send(new GetCustomerByIdQuery(Id));
        }

        [HttpPut("update/{Id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int Id, [FromBody] CustomerEntity Customer)
        {
            bool result = await sender.Send(new UpdateCustomerDataCommand(Id, Customer));

            return result ? Ok() : NotFound();
        }
    }
}
