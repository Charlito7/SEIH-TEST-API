namespace Core.Application.Model.Features;

public class HospitalDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Department { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
}
