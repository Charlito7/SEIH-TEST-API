
using Core.Application.Commons.ServiceResult;
using Core.Application.Model.Request.Transfert;
using Core.Application.Model.Response.Transfert;
using System.Security.Claims;

namespace Core.Application.Interface.Services.SEIH.Transfert;

public interface ITransfertServices
{
    Task<ServiceResult<List<TransfertResponse>>> GetAllTransfertAsync(ClaimsPrincipal claim);
    Task<ServiceResult<List<TransfertRequestResponse>?>> GetAllTransfertRequestAsync(ClaimsPrincipal claim);
    Task<ServiceResult<TransfertRequestResponse>> GetAllTransfertRequestByHospitalAsync(Guid hospitalId);
    Task<ServiceResult<bool>> CreateTransfertRequestAsync(ClaimsPrincipal claim, TransfertRequestDTO transfert);
    Task<ServiceResult<bool>> CreateTransfertAsync(ClaimsPrincipal claim,TransfertDTO transfert);
}
