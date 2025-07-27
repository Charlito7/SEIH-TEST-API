namespace Core.Domain.Entity.SEIH;

public class PermissionEntity
{
    public Guid Id { get; set; }
    public string? HttpMethod { get; set; }  // GET, POST, etc.
    public string? Path { get; set; }
    public string? Name { get; set; }
}
