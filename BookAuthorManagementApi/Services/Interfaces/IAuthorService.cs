using BookAuthorManagementApi.Entities;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;

namespace BookAuthorManagementApi.Services.Interfaces;

public interface IAuthorService
{
    Task<AuthorResponseVm> CreateAuthorAsync(AuthorRequestVm authorRequestVm);
    Task<IEnumerable<AuthorResponseVm>> GetAllAuthors();
    Task<AuthorResponseVm> GetAuthorById(string id);
    Task<Author> GetAuthorByIdOri(string id);
    Task<AuthorResponseVm> UpdateAuthor(string id, AuthorRequestVm? authorRequestVm, bool isDelete = false);
}