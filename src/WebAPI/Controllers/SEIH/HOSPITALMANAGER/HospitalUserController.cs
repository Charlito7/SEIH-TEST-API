using Core.Application.Interface.Services.SEIH;
using Core.Application.Interface.Services.SEIH.User;
using Core.Application.Model.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebAPI.Controllers.SEIH.HOSPITALMANAGER;

[ApiController]
[Route("seih/hospital/user")]
public class HospitalUserController : BaseController
{
    private readonly IHospitalUserService _service;

    public HospitalUserController(IHospitalUserService service)
    {
        _service = service;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("create", Name = "HospitalUserCreate")]
    public async Task<IActionResult> CreateUserAccountAsync(CreateUserModel model)
    {
        var result = await _service.HospitalCreateUserServiceAsync(User, model);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("addRole", Name = "HospitalUserAddRole")]
    public async Task<IActionResult> AddRoleAsync(CreateUserModel model)
    {
        var result = await _service.HospitalCreateUserServiceAsync(User, model);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("update/password", Name = "HospitalUserUpdatePassword")]
    public async Task<IActionResult> UpdateUserPasswordAsync(ChangePasswordModel model)
    {
        var result = await _service.HospitalUpdateUserPasswordServiceAsync(User, model);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("update/passwordByManager", Name = "HospitalUserUpdatePasswordByManager")]
    public async Task<IActionResult> UpdateUserPasswordAsync(ChangePasswordByManagerModel model)
    {
        var result = await _service.HospitalUpdateUserPasswordByManagerServiceAsync(User, model);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("update/profile", Name = "HospitalUserUpdateProfile")]
    public async Task<IActionResult> UpdateUserProfileAsync(CreateUserModel model)
    {
        var result = await _service.HospitalCreateUserServiceAsync(User, model);

        if (result.IsError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
