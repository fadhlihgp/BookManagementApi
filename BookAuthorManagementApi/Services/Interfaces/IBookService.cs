using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;

namespace BookAuthorManagementApi.Services.Interfaces;

public interface IBookService
{
    Task<BookResponseVm> CreateBookAsync(BookRequestVm bookRequestVm);
    Task<IEnumerable<BookResponseVm>> GetAllBooksAsync();
    Task<BookResponseVm> GetBookByIdAsync(string id);
    Task<BookResponseVm> UpdateBook(string id, BookRequestVm bookRequestVm);
    Task DeleteBook(string id);
}