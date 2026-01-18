using AutoMapper;
using Core.Application.Commons.ServiceResult;
using Core.Application.Interface.Repository.SEIH;
using Core.Application.Interface.Repository.SEIH.Transfert;
using Core.Application.Interface.Services.Emails;
using Core.Application.Interface.Services.SEIH.Transfert;
using Core.Application.Model.Request.Transfert;
using Core.Application.Model.Response.Transfert;
using Core.Domain.Entity.SEIH;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;


namespace Infrastructure.Services.SEIH.Transfert;

public class TransfertServices : ITransfertServices
{
    private readonly ITransfertRepository _transfertRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public TransfertServices(
        ITransfertRepository transfertRepository,
        IUsersRepository usersRepository,
        IHospitalRepository hospitalRepository,
        IEmailService emailService,
        IMapper mapper)
    {
        _transfertRepository = transfertRepository;
        _usersRepository = usersRepository;
        _hospitalRepository = hospitalRepository;
        _emailService = emailService;
        _mapper = mapper;

    }
    public async Task<ServiceResult<bool>> CreateTransfertAsync(ClaimsPrincipal claim,TransfertDTO transfert)
    {
        var email = claim.Claims
              .Where(c => c.Type == System.Security.Claims.ClaimTypes.Email)
              .Select(c => c.Value)
              .FirstOrDefault();

        var manager = await _usersRepository.GetUserByEmailAsync(email!);
        if (manager == null)
        {
            return new ServiceResult<bool>(HttpStatusCode.Unauthorized);
        }

        var hospital = await _hospitalRepository.GetHospitalByNameAsync(transfert.HospitalDestination);
        if (hospital == null)
        {
            return new ServiceResult<bool>(HttpStatusCode.Unauthorized);
        }
        TransfertEntity transfertEntity = new TransfertEntity
        {
            IdHospitalFrom = manager.HospitalId,
            IdHospitalTo = hospital.Id,
            EncryptedSessionKey = transfert.EncryptedSessionKey,
            PatientRecord = transfert.PatientRecord,
            Message = transfert.Message,
            RequestReference = transfert.RequestReference
        };

        var result = await _transfertRepository.CreateTransfertAsync(transfertEntity);

        if (result == null) {
            return new ServiceResult<bool>(HttpStatusCode.Unauthorized);
        }
        return new ServiceResult<bool>(true);
    }

    public async Task<ServiceResult<bool>> CreateTransfertRequestAsync(ClaimsPrincipal claim, TransfertRequestDTO transfert)
    {
        var email = claim.Claims
              .Where(c => c.Type == System.Security.Claims.ClaimTypes.Email)
              .Select(c => c.Value)
              .FirstOrDefault();

        var manager = await _usersRepository.GetUserByEmailAsync(email!);
        if (manager == null)
        {
            return new ServiceResult<bool>(HttpStatusCode.Unauthorized);
        }

        var hospital = await _hospitalRepository.GetHospitalByNameAsync(transfert.HospitalDestination!);
        if (hospital == null)
        {
            return new ServiceResult<bool>(HttpStatusCode.Unauthorized);
        }
        if(manager.HospitalId == hospital.Id)
        {
            return new ServiceResult<bool>(HttpStatusCode.Unauthorized);
        }
        TransfertRequestEntity transfertRequestEntity = new TransfertRequestEntity
        {
            IdHospitalFrom = manager.HospitalId,
            IdHospitalTo = hospital.Id,
            InfoPatient = transfert.PatientInfo,
            TransfertNumber = hospital.Code + "-" + Generate6DigitCode(),
            Status = "NEW",
            RequestCause = transfert.RequestCause,
            CreatedBy = manager.Id.ToString(),
            Created = DateTime.UtcNow
        };

        var result = await _transfertRepository.CreateTransfertRequestAsync(transfertRequestEntity);
        await _emailService.SendEmailAsync(
    to: new List<string> { "WilbensonCharles7@gmail.com", "francketiennejeudy380@gmail.com", "wadlinepierressaint1@gmail.com"},
    subject: "(SEIH - Nouvelle requete de transfert",
    body: "Bonsoir,\n\nVous avez une nouvelle requete "+  transfertRequestEntity.Id
);
        if (result == null)
        {
            return new ServiceResult<bool>(HttpStatusCode.Unauthorized);
        }
        return new ServiceResult<bool>(true);
    }

    public async Task<ServiceResult<List<TransfertResponse>>> GetAllTransfertAsync(ClaimsPrincipal claim)
    {
        var email = claim.Claims
        .Where(c => c.Type == System.Security.Claims.ClaimTypes.Email)
        .Select(c => c.Value)
        .FirstOrDefault();

        var manager = await _usersRepository.GetUserByEmailAsync(email!);
        if (manager == null)
        {
            throw new NotImplementedException();
        }

        var result = await _transfertRepository.GetAllTransfertRequestByHospitalAsync(manager!.HospitalId);
        return _mapper.Map<ServiceResult<List<TransfertResponse>>>(result);
    }

    public async Task<ServiceResult<List<TransfertRequestResponse>>> GetAllTransfertRequestAsync(ClaimsPrincipal claim)
    {
        var email = claim.Claims
       .Where(c => c.Type == System.Security.Claims.ClaimTypes.Email)
       .Select(c => c.Value)
       .FirstOrDefault();

        var manager = await _usersRepository.GetUserByEmailAsync(email!);
        if (manager == null)
        {
            throw new NotImplementedException();
        }

        var result = await _transfertRepository.GetAllTransfertRequestByHospitalAsync(manager!.HospitalId);
        return _mapper.Map<ServiceResult<List<TransfertRequestResponse>>>(result);
    }

    public Task<ServiceResult<TransfertRequestResponse>> GetAllTransfertRequestByHospitalAsync(Guid hospitalId)
    {
        throw new NotImplementedException();
    }

    public static string Generate6DigitCode()
    {
        int number = RandomNumberGenerator.GetInt32(0, 1_000_000);
        return number.ToString("D6"); // toujours 6 chiffres
    }
}
