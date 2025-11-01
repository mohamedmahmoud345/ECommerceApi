
using Application.IUnitOfWorks;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCustomerHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
            if (customer != null)
            {
                var customerMapper = _mapper.Map<Customer>(request);
                await _unitOfWork.Customers.Update(customerMapper);
                await _unitOfWork.SaveChangesAsync();          
            }
        }
    }
}
