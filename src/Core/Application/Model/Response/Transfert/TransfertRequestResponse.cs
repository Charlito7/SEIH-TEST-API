
namespace Core.Application.Model.Response.Transfert;

public class TransfertRequestResponse 
{
    public string? PatientInfo { get; set; }
    public string? HospitalFrom { get; set; }
    public string? HospitalTo { get; set; }
    public string? RequestCause { get; set; }
    public string? TransfertNumber { get; set; }
    public string? Status { get; set; }
    public DateTime Created { get; set; }
}
