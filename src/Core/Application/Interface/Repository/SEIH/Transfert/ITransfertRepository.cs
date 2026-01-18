

using Core.Application.Model.Request.Transfert;
using Core.Domain.Entity.SEIH;
using System.Threading.Tasks;

namespace Core.Application.Interface.Repository.SEIH.Transfert;

public interface ITransfertRepository
{
    Task<List<TransfertEntity>> GetAllTransfertAsync();
    Task<List<TransfertRequestEntity>> GetAllTransfertRequestAsync();
    Task<List<TransfertRequestEntity>> GetAllTransfertRequestByHospitalAsync(Guid hospitalId);
    Task<TransfertRequestEntity?> DeleteTransfertRequest(string hospitalId);
    Task<TransfertRequestEntity> CreateTransfertRequestAsync(TransfertRequestEntity transfertRequest);
    Task<TransfertEntity> CreateTransfertAsync(TransfertEntity transfertRequest);

}
