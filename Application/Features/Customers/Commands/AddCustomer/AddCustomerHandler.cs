
using Application.IUnitOfWorks;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, AddCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddCustomerResponse?> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerMapper = _mapper.Map<Customer>(request);
            if (_unitOfWork.Customers.GetByEmailAsync(request.Email) != null)
                return null;
            var customer = await _unitOfWork.Customers.AddAsync(customerMapper);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<AddCustomerResponse>(customer);
        }
    }
}
