using BookAuthorManagementApi.Entities;

namespace BookAuthorManagementApi.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> FindUserByUserName(string userName);
}