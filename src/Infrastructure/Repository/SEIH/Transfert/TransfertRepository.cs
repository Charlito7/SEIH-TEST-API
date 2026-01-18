

using Core.Application.Interface.Repository.SEIH.Transfert;
using Core.Application.Model.Request.Transfert;
using Core.Domain.Entity.SEIH;
using Infrastructure.Services.SEIH.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.SEIH.Transfert;

public class TransfertRepository : ITransfertRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<UserService> _logger;

    public TransfertRepository(AppDbContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<TransfertEntity> CreateTransfertAsync(TransfertEntity transfert)
    {
        if (transfert == null)
            throw new ArgumentNullException(nameof(transfert));
        await _context.Transferts.AddAsync(transfert);
        await _context.SaveChangesAsync();
        return transfert;
    }

    public async Task<TransfertRequestEntity> CreateTransfertRequestAsync(TransfertRequestEntity transfertRequest)
    {
        if (transfertRequest == null)
            throw new ArgumentNullException(nameof(transfertRequest));
        await _context.TransfertRequests.AddAsync(transfertRequest);
        await _context.SaveChangesAsync();
        return transfertRequest;
    }

    public Task<TransfertRequestEntity?> DeleteTransfertRequest(string hospitalId)
    {
        throw new NotImplementedException();
    }

    public Task<List<TransfertEntity>> GetAllTransfertAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<TransfertRequestEntity>> GetAllTransfertRequestAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<TransfertRequestEntity>> GetAllTransfertRequestByHospitalAsync(Guid hospitalId)
    {
        return await _context.TransfertRequests
            .Where(tr => tr.IdHospitalTo == hospitalId)
            .ToListAsync();

    }
}
