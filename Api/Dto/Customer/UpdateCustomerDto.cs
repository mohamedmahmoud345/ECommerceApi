namespace Api.Dto.Customer
{

    public record UpdateCustomerDto(Guid Id, string? Name, string? Email,
        string? Phone, string? Address);
}
