namespace Core.Domain.Procedures.SEIH;

public class GetUserListWithRolesResponse
{
    public Guid? UserId { get; set; }
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string? UserName { get; set; } = string.Empty;
    public string? Roles { get; set; } = string.Empty;
}
