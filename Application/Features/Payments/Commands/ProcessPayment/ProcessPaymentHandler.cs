using System;
using Application.Interfaces.Services;
using Application.IUnitOfWorks;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using MediatR;

namespace Application.Features.Payments.Commands.ProcessPayment
{
    public class ProcessPaymentHandler
        : IRequestHandler<ProcessPaymentCommand, ProcessPaymentResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public ProcessPaymentHandler(IUnitOfWork unitOfWork, IMapper mapper, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paymentService = paymentService;
        }

        public async Task<ProcessPaymentResponse> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
            if (order is null)
                throw new NullReferenceException();
            if (order.Status != OrderStatus.Pending)
                throw new InvalidOperationException("Only pending orders can be paid");
            if (order.TotalAmount <= 0)
                throw new InvalidOperationException("Order amount must be greater than zero");

            var payment =
             new Payment(request.OrderId, order.TotalAmount, request.PaymentMethod, PaymentStatus.Pending, DateTime.UtcNow);

            var success = await _paymentService.ProcessPaymentAsync(payment.Amount, payment.Method);

            if (success)
                payment.UpdateStatus(PaymentStatus.Completed);
            else
                payment.UpdateStatus(PaymentStatus.Failed);

            if (payment.Status == PaymentStatus.Completed)
                order.UpdateStatus(OrderStatus.Paid);

            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.SaveChangesAsync();

            var response = _mapper.Map<ProcessPaymentResponse>(payment);

            return response;
        }
    }
}
