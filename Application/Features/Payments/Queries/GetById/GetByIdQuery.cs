using System;
using MediatR;

namespace Application.Features.Payments.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdResponse>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
