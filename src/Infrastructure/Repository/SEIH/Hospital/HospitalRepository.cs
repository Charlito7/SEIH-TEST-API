
using Core.Application.Interface.Repository.SEIH;
using Core.Domain.Entity.SEIH;
using Infrastructure.Services.SEIH.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.SEIH.Hospital;

public class HospitalRepository : IHospitalRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<UserService> _logger;

    public HospitalRepository(AppDbContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }
    public Task AddAsync(HospitalEntity hospital)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<HospitalEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<HospitalEntity?> GetHospitalByIdAsync(Guid hospitalId)
    {
        if (string.IsNullOrWhiteSpace(hospitalId.ToString()))
            return null;

        return await _context.Hospitals
                             .Where(u => u.Id == hospitalId && (u.IsDeleted == null || u.IsDeleted == false))
                             .FirstOrDefaultAsync();
    }

    public async Task<HospitalEntity?> GetHospitalByNameAsync(string hospitalName)
    {
        if (string.IsNullOrWhiteSpace(hospitalName))
            return null;

        return await _context.Hospitals
                             .Where(u => u.Name == hospitalName && (u.IsDeleted == null || u.IsDeleted == false))
                             .FirstOrDefaultAsync();
    }



    public Task UpdateAsync(HospitalEntity hospital)
    {
        throw new NotImplementedException();
    }
}
