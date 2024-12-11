using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;

namespace BookAuthorManagementApi.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponseVm> Login(LoginRequestVm loginRequestVm);
}