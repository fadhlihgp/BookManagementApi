using BookAuthorManagementApi.Context;
using BookAuthorManagementApi.Entities;
using BookAuthorManagementApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorManagementApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> FindUserByUserName(string userName)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());
    }
}