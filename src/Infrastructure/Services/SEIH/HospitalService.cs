using AutoMapper;
using Core.Application.Commons.ServiceResult;
using Core.Application.Interface.Repository.SEIH;
using Core.Application.Interface.Services.SEIH;
using Core.Application.Model.Features;
using Core.Domain.Entity.SEIH;
using System.Net;
using System.Security.Claims;

namespace Infrastructure.Services.SEIH;

public class HospitalService : IHospitalService
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public HospitalService(
        IHospitalRepository hospitalRepository,
        IUsersRepository usersRepository,
        IMapper mapper)
    {
        _hospitalRepository = hospitalRepository;
        _usersRepository = usersRepository;
        _mapper = mapper;
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

    public async Task<ServiceResult<List<HospitalDto>>> GetAllAsync()
    {
     
        var hospitals = await _hospitalRepository.GetAllAsync();
        var hospitalDtos = _mapper.Map<List<HospitalDto>>(hospitals);   

        return new ServiceResult<List<HospitalDto>>(hospitalDtos, true, HttpStatusCode.OK, "");
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
