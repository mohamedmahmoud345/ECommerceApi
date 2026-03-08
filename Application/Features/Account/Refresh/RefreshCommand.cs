using MediatR;

namespace Application.Features.Account.Refresh
{
    public class RefreshCommand : IRequest<RefreshResponse?>
    {
        public required string RefreshToken { get; set; }
    }
}
