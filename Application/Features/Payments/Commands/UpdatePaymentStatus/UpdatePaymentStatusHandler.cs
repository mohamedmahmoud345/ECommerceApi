using System;
using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Payments.Commands.UpdatePaymentStatus
{
    public class UpdatePaymentStatusHandler
    : IRequestHandler<UpdatePaymentStatusCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePaymentStatusHandler(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }
        public async Task<bool> Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(request.Id);
            if (payment is null)
                return false;

            try
            {
                payment.UpdateStatus(request.PaymentStatus);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            
            return true;
        }
    }
}
