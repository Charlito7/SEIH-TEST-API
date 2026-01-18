

using System.ComponentModel.DataAnnotations;

namespace Core.Application.Model.Request.Transfert;

public class TransfertDTO
{
    [Required]
    public string HospitalDestination { get; set; } = default!;
    [Required]
    public string? PatientRecord { get; set; }
    [Required]
    public string? EncryptedSessionKey { get; set; }
    public string? Message { get; set; }
    public Guid? RequestReference { get; set; }
}
