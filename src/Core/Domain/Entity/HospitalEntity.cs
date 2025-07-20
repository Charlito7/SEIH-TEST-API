using Core.Domain.Commons;


namespace Core.Domain.Entity
{
    public class HospitalEntity : AuditableEntity
    {
        public string? Name { get; set; }
        public string?Code { get; set; }
        public string? Address { get; set; }
    }

}
