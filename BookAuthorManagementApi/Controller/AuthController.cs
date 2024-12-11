using BookAuthorManagementApi.Services.Interfaces;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorManagementApi.Controller;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestVm loginRequestVm)
    {
        var data = await _authService.Login(loginRequestVm);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully login",
            Data = data
        });
    }
}