using EventSourcing.API.Dtos;
using MediatR;

namespace EventSourcing.API.Queries
{
    public class GetByProductId:IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }
    }
}
