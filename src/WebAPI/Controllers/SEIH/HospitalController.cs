using Core.Application.Interface.Services.SEIH;
using Core.Application.Model.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebAPI.Controllers.SEIH;

[ApiController]
[Route("seih/hospital")]
public class HospitalController : BaseController
{
    private readonly IHospitalService _service;
    public HospitalController(IHospitalService service)
    {
        _service = service;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("getlist", Name = "getlist")]
    public async Task<IActionResult> GetHospitalList()
    {
        var result = await _service.GetAllAsync();

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

}
