
using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var cutsomer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
            if (cutsomer == null)
                return false;

            await _unitOfWork.Customers.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
