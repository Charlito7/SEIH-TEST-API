
using System.ComponentModel.DataAnnotations;

namespace Core.Application.Model.Request.Transfert;

public class TransfertRequestDTO
{
    [Required]
    public string? PatientInfo { get; set; }
    [Required]
    public string? HospitalDestination { get; set; }
    [Required]
    public string ? RequestCause { get; set; }
}
