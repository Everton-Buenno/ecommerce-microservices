using Catalog.API.Products.Commands.CreateProduct;
using Catalog.API.Products.Commands.DeleteProduct;
using Catalog.API.Products.Commands.UpdateProduct;
using Catalog.API.Products.Queries.GetProductById;
using Catalog.API.Products.Queries.GetProducts;
using Catalog.API.Products.Queries.GetProductsByCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(Create), new { id = result.Data }, result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }


        [HttpGet]
        [Route("health")]
        public IActionResult Health()
        {
            return Ok("Catalog API is healthy...");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [HttpGet]
        [Route("category/{category}")]
        public async Task<IActionResult> GetByCategory([FromRoute] string category)
        {
            var query = new GetProductsByCategoryQuery(category);
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }
    }
}
