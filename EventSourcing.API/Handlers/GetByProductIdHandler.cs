using EventSourcing.API.Dtos;
using EventSourcing.API.Models;
using EventSourcing.API.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.API.Handlers
{
    public class GetByProductIdHandler : IRequestHandler<GetByProductId, ProductDto>
    {
        private readonly AppDbContext _context;
        public GetByProductIdHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> Handle(GetByProductId request, CancellationToken cancellationToken)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);
            ProductDto productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
            return productDto;
        }
    }
}
