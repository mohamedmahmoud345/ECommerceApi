namespace Api.Dto.CustomerDto
{

    public record UpdateCustomerDto(Guid Id, string? Name, string? Email,
        string? Phone, string? Address);
}
