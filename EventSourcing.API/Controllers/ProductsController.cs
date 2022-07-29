﻿using EventSourcing.API.Commands;
using EventSourcing.API.Dtos;
using EventSourcing.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            await _mediator.Send(new CreateProductCommand()
            {
                CreateProductDto = createProductDto
            });
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> ChangeName(ChangeProductNameDto changeProductNameDto)
        {
            await _mediator.Send(new ChangeProductNameCommand()
            {
                ChangeProductNameDto = changeProductNameDto
            });
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> ChangePrice(ChangeProductPriceDto changeProductPriceDto)
        {
            await _mediator.Send(new ChangeProductPriceCommand()
            {
                ChangeProductPriceDto = changeProductPriceDto
            });
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand()
            {
                Id = id
            });
            return NoContent();
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllListByUserId(int userId)
        {
            return Ok(await _mediator.Send(new GetProductAllListByUserId() { UserId = userId}));
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProductId(Guid productId)
        {
            return Ok(await _mediator.Send(new GetByProductId() { ProductId=productId}));
        }
    }
}
