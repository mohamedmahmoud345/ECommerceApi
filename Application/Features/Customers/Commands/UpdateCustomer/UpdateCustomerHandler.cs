
using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
            if (customer == null)
                return false;

            if (!string.IsNullOrWhiteSpace(request.Name))
                customer.Rename(request.Name);

            if (!string.IsNullOrWhiteSpace(request.Address))
                customer.ChangeAddress(request.Address);

            if (!string.IsNullOrWhiteSpace(request.Phone))
                customer.ChangePhone(request.Phone);

            await _unitOfWork.Customers.Update(customer);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
