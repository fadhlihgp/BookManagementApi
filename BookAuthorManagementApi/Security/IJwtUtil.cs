using BookAuthorManagementApi.Entities;

namespace BookAuthorManagementApi.Security;

public interface IJwtUtil
{
    string GenerateToken(User user);
}