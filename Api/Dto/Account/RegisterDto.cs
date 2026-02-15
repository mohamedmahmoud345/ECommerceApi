namespace Api.Dto.Account
{
    public record class RegisterDto(
        string Name,
        string Email,
        string Password,
        string Phone,
        string Address
    );
}
