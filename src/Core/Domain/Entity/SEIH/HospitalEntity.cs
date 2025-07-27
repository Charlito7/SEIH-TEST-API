using Core.Domain.Commons;


namespace Core.Domain.Entity.SEIH
{
    public class HospitalEntity : AuditableEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Address { get; set; }
        public string City { get; set; } = default!;
        public string Department { get; set; } = default!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        
    }

}
