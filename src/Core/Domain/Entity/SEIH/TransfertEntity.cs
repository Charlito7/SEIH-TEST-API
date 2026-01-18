using Core.Domain.Commons;

namespace Core.Domain.Entity.SEIH;

public class TransfertEntity : AuditableEntity
{
        public Guid IdHospitalFrom { get; set; } = default!;
        public Guid? IdHospitalTo { get; set; } = default!;

        public string? PatientRecord { get; set; }

        public string? EncryptedSessionKey { get; set; }
        public string? Message { get; set; }
        public Guid? RequestReference { get; set; }

}
