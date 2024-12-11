using BookAuthorManagementApi.Context;
using BookAuthorManagementApi.Entities;
using BookAuthorManagementApi.Exceptions;
using BookAuthorManagementApi.Repositories.Interfaces;
using BookAuthorManagementApi.Services.Interfaces;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace BookAuthorManagementApi.Services;

public class BookService : IBookService
{
    private readonly IPublisherService _publisherService;
    private readonly IAuthorService _authorService;
    private readonly IRepository<Book> _repository;
    private readonly IPersistence _persistence;
    private readonly IGenericMemoryCacheService _genericMemoryCacheService;

    public BookService(IRepository<Book> repository, IPersistence persistence, IGenericMemoryCacheService genericMemoryCacheService, IAuthorService authorService, IPublisherService publisherService)
    {
        _repository = repository;
        _persistence = persistence;
        _genericMemoryCacheService = genericMemoryCacheService;
        _authorService = authorService;
        _publisherService = publisherService;
    }

    public async Task<BookResponseVm> CreateBookAsync(BookRequestVm bookRequestVm)
    {
        try
        {
            var book = new Book
            {
                Title = bookRequestVm.Title,
                PublicationYear = bookRequestVm.PublicationYear,
                Description = bookRequestVm.Description,
                Publisher = await _publisherService.GetPublisherByIdOri(bookRequestVm.PublisherId),
                Author = await _authorService.GetAuthorByIdOri(bookRequestVm.AuthorId)
            };

            var save = await _repository.Save(book);
            await _persistence.SaveChangesAsync();
            _genericMemoryCacheService.Remove("BookList");
            return new BookResponseVm
            {
                Id = save.Id,
                Description = save.Description,
                Title = save.Title,
                PublicationYear = save.PublicationYear,
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<BookResponseVm>> GetAllBooksAsync()
    {
        return await _genericMemoryCacheService.GetOrCreate("BookList", async () =>
        {
            var data = await _repository.FindAll(new[] { "Author", "Publisher" });
            return data.Select(book => new BookResponseVm
            {
                Id = book.Id,
                Title = book.Title,
                PublicationYear = book.PublicationYear,
                Description = book.Description,
                Author = new AuthorResponseBook
                {
                    Id = book.Author.Id,
                    FullName = book.Author.FullName,
                    Address = book.Author.Address,
                    Phone = book.Author.Phone,
                    BirthDate = book.Author.BirthDate,

                },
                Publisher = new PublisherResponseBook
                {
                    Id = book.Publisher.Id,
                    Name = book.Publisher.Name,
                    Address = book.Publisher.Address,
                    Phone = book.Publisher.Phone
                }
            });
        });
    }

    public async Task<BookResponseVm> GetBookByIdAsync(string id)
    {
        var data = await _repository.Find(e => e.Id == id, new[] { "Author", "Publisher" });
        if (data == null) throw new NotFoundException("Book not found");
        return new BookResponseVm
        {
            Id = data.Id,
            Title = data.Title,
            PublicationYear = data.PublicationYear,
            Description = data.Description,
            Author = new AuthorResponseBook
            {
                Id = data.Author.Id,
                FullName = data.Author.FullName,
                Address = data.Author.Address,
                Phone = data.Author.Phone,
                BirthDate = data.Author.BirthDate,

            },
            Publisher = new PublisherResponseBook
            {
                Id = data.Publisher.Id,
                Name = data.Publisher.Name,
                Address = data.Publisher.Address,
                Phone = data.Publisher.Phone
            }
        };
    }

    public async Task<BookResponseVm> UpdateBook(string id, BookRequestVm bookRequestVm)
    {
        var data = await _repository.Find(b => b.Id.Equals(id));
        if (data == null) throw new NotFoundException("Book Not Found");

        data.Title = bookRequestVm.Title;
        data.AuthorId = bookRequestVm.AuthorId;
        data.PublisherId = bookRequestVm.PublisherId;
        data.Description = bookRequestVm.Description;
        data.PublicationYear = bookRequestVm.PublicationYear;
        var save = _repository.Update(data);
        await _persistence.SaveChangesAsync();
        _genericMemoryCacheService.Remove("BookList");
        return new BookResponseVm
        {
            Id = save.Id,
            Title = save.Title,
            PublicationYear = save.PublicationYear,
            Description = save.Description
        };
    }

    public async Task DeleteBook(string id)
    {
        var data = await _repository.Find(b => b.Id.Equals(id));
        if (data == null) throw new NotFoundException("Book Not Found");
        
        _repository.Delete(data);
        await _persistence.SaveChangesAsync();
        _genericMemoryCacheService.Remove("BookList");
    }
}