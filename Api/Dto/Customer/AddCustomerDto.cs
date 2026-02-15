namespace Api.Dto.Customer
{
    public record AddCustomerDto(string Name, Guid UserId, string Phone, string Address);
}
