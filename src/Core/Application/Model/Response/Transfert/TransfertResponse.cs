

namespace Core.Application.Model.Response.Transfert;

public class TransfertResponse
{
    public string IdHospitalFrom { get; set; } = default!;
    public string IdHospitalTo { get; set; } = default!;

    public string? PatientRecord { get; set; }

    public string? EncryptedSessionKey { get; set; }
}
