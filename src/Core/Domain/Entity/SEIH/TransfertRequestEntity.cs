using Core.Domain.Commons;


namespace Core.Domain.Entity.SEIH;

public class TransfertRequestEntity : AuditableEntity
{
    public string? InfoPatient { get; set; }
    public string? Status { get; set;}
    public string? RequestCause { get; set; }
    public string? TransfertNumber { get; set; }
    public Guid? IdHospitalFrom { get; set; }
    public Guid? IdHospitalTo { get; set; } 

}
