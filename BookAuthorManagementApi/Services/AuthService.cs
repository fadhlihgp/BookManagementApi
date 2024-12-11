using BookAuthorManagementApi.Entities;
using BookAuthorManagementApi.Exceptions;
using BookAuthorManagementApi.Repositories.Interfaces;
using BookAuthorManagementApi.Security;
using BookAuthorManagementApi.Services.Interfaces;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;

namespace BookAuthorManagementApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtUtil _jwtUtil;

    public AuthService(IUserRepository userRepository, IJwtUtil jwtUtil)
    {
        _userRepository = userRepository;
        _jwtUtil = jwtUtil;
    }

    public async Task<LoginResponseVm> Login(LoginRequestVm loginRequestVm)
    {
        var user = await _userRepository.FindUserByUserName(loginRequestVm.UserName);
        if (user == null) throw new UnauthorizedException("Wrong username or password");
        
        bool isValid = BCrypt.Net.BCrypt.Verify(loginRequestVm.Password, user.Password);
        if (!isValid) throw new UnauthorizedException("Wrong username or password");

        string token = _jwtUtil.GenerateToken(user);
        return new LoginResponseVm
        {
            UserName = user.UserName,
            Role = user.Role,
            Token = token
        };
    }
}