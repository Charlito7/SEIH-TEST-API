using Core.Application.Interface.Services.SEIH.Transfert;
using Core.Application.Model.Request.Transfert;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebAPI.Controllers.SEIH.Transfert;

[ApiController]
[Route("seih/transfert")]
public class TransfertController : BaseController
{
    private readonly ITransfertServices _service;

    public TransfertController(ITransfertServices service)
    {
        _service = service;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("create", Name = "create")]
    public async Task<IActionResult> createTransfertAsync(TransfertDTO model)
    {
        var result = await _service.CreateTransfertAsync(User,model);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("request", Name = "request")]
    public async Task<IActionResult> createTransfertRequestAsync(TransfertRequestDTO model)
    {
        var result = await _service.CreateTransfertRequestAsync(User,model);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("getalltransfert", Name = "getalltransfert")]
    public async Task<IActionResult> GetAllTransfertAsync()
    {
        var result = await _service.GetAllTransfertAsync(User);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("getalltransfertrequest", Name = "getalltransfertrequest")]
    public async Task<IActionResult> GetAllTransfertRequestAsync()
    {
        var result = await _service.GetAllTransfertAsync(User);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("getAllTransfertRequestByHospital", Name = "getAllTransfertRequestByHospital")]
    public async Task<IActionResult> getAllTransfertRequestByHospitalAsync(Guid hospitalId)
    {
        var result = await _service.GetAllTransfertRequestByHospitalAsync(hospitalId);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
