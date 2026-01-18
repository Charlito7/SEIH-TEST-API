using Core.Application.Commons.ServiceResult;
using Core.Application.Model.Features;
using System.Security.Claims;

namespace Core.Application.Interface.Services.SEIH;

public interface IHospitalService
{
    Task<ServiceResult<List<HospitalDto>>> GetAllAsync(); 
    Task<ServiceResult<HospitalDto?>> GetByIdAsync(Guid id);
    Task<ServiceResult<bool>> AddAsync(HospitalDto dto);
    Task<ServiceResult<bool>> UpdateAsync(HospitalDto dto);
    Task<ServiceResult<bool>> DeleteAsync(Guid id);
}
