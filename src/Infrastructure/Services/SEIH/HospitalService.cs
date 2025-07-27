using Core.Application.Commons.ServiceResult;
using Core.Application.Interface.Repository.SEIH;
using Core.Application.Interface.Services.SEIH;
using Core.Application.Model.Features;
using Core.Domain.Entity.SEIH;
using System.Net;

namespace Infrastructure.Services.SEIH;

public class HospitalService : IHospitalService
{
    private readonly IHospitalRepository _hospitalRepository;
    public HospitalService(IHospitalRepository hospitalRepository)
    {
        _hospitalRepository = hospitalRepository;
    }   
    public async Task<ServiceResult<bool>> AddAsync(HospitalDto dto)
    {
        var entity = new HospitalEntity
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            Email = dto.Email,
            Department = dto.Department,
            PhoneNumber = dto.PhoneNumber
        };
        try
        {
            await _hospitalRepository.AddAsync(entity);
            return new ServiceResult<bool>(true, true, HttpStatusCode.OK, "");
        }
        catch
        {
            return new ServiceResult<bool>(false, false, HttpStatusCode.BadRequest, "");
        }
               
    }

    public Task<ServiceResult<bool>> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<List<HospitalDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<HospitalDto?>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<bool>> UpdateAsync(HospitalDto dto)
    {
        throw new NotImplementedException();
    }
}
