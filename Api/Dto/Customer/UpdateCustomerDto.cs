namespace Api.Dto.Customer
{

    public record UpdateCustomerDto(Guid Id, string? Name,
        string? Phone, string? Address);
}
