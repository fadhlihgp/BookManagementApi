using BookAuthorManagementApi.Context;
using BookAuthorManagementApi.Entities;
using BookAuthorManagementApi.Exceptions;
using BookAuthorManagementApi.Repositories.Interfaces;
using BookAuthorManagementApi.Services.Interfaces;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;

namespace BookAuthorManagementApi.Services;

public class AuthorService : IAuthorService
{
    private readonly IRepository<Author> _authorRepository;
    private readonly IGenericMemoryCacheService _genericMemoryCacheService;
    private readonly IPersistence _persistence;
    
    public AuthorService(IRepository<Author> authorRepository, IGenericMemoryCacheService genericMemoryCacheService, IPersistence persistence)
    {
        _authorRepository = authorRepository;
        _genericMemoryCacheService = genericMemoryCacheService;
        _persistence = persistence;
    }

    public async Task<AuthorResponseVm> CreateAuthorAsync(AuthorRequestVm authorRequestVm)
    {
        Author author = new Author
        {
            FullName = authorRequestVm.FullName,
            Address = authorRequestVm.Address,
            Phone = authorRequestVm.Phone,
            BirthDate = authorRequestVm.BirthDate,
        };
        var save = await _authorRepository.Save(author);
        await _persistence.SaveChangesAsync();
        _genericMemoryCacheService.Remove("AuthorList");
        return new AuthorResponseVm
        {
            Id = save.Id,
            FullName = save.FullName,
            Address = save.Address,
            Phone = save.Phone,
            BirthDate = save.BirthDate
        };
    }

    public async Task<IEnumerable<AuthorResponseVm>> GetAllAuthors()
    {
        return await _genericMemoryCacheService.GetOrCreate("AuthorList", async () =>
        {
            var authors = await _authorRepository.FindAll(author => !author.IsDeleted, new[] { "Books", "Books.Publisher" });
            return authors.Select(a => new AuthorResponseVm
            {
                Id = a.Id,
                FullName = a.FullName,
                Address = a.Address,
                Phone = a.Phone,
                BirthDate = a.BirthDate,
                Books = a.Books.Select(book => new BookResponseVm
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublicationYear = book.PublicationYear,
                    Description = book.Description,
                    Author = new AuthorResponseBook
                    {
                        Id = a.Id,
                        FullName = a.FullName,
                        Address = a.Address,
                        Phone = a.Phone,
                        BirthDate = a.BirthDate
                    },
                    Publisher = new PublisherResponseBook
                    {
                        Id = book.Publisher.Id,
                        Address = book.Publisher.Address,
                        Phone = book.Publisher.Phone,
                        Name = book.Publisher.Name
                    }
                })
            });
        });
    }

    public async Task<AuthorResponseVm> GetAuthorById(string id)
    {
        var data = await _authorRepository.Find(a => a.Id.Equals(id) && !a.IsDeleted, new[] { "Books", "Books.Publisher" });
        if (data == null) throw new NotFoundException("Author not found");
        return new AuthorResponseVm
        {
            Id = data.Id,
            FullName = data.FullName,
            Address = data.Address,
            Phone = data.Phone,
            BirthDate = data.BirthDate,
            Books = data.Books.Select(book => new BookResponseVm
            {
                Id = book.Id,
                Title = book.Title,
                PublicationYear = book.PublicationYear,
                Description = book.Description,
                Author = new AuthorResponseBook
                {
                    Id = data.Id,
                    FullName = data.FullName,
                    Address = data.Address,
                    Phone = data.Phone,
                    BirthDate = data.BirthDate
                },
                Publisher = new PublisherResponseBook
                {
                    Id = book.Publisher.Id,
                    Address = book.Publisher.Address,
                    Phone = book.Publisher.Phone,
                    Name = book.Publisher.Name
                }
            })
        };
    }

    public async Task<Author> GetAuthorByIdOri(string id)
    {
        var data = await _authorRepository.Find(a => !a.IsDeleted && a.Id.Equals(id));
        if (data == null) throw new NotFoundException("Author Not Found");
        return data;
    }

    public async Task<AuthorResponseVm> UpdateAuthor(string id, AuthorRequestVm? authorRequestVm, bool isDelete = false)
    {
        var data = await GetAuthorByIdOri(id);

        if (isDelete)
        {
            data.IsDeleted = true;
        }
        else
        {
            if (authorRequestVm == null) throw new BadRequestException("Author Request Body is Required");
            data.BirthDate = authorRequestVm.BirthDate;
            data.Address = authorRequestVm.Address;
            data.FullName = authorRequestVm.FullName;
            data.Phone = authorRequestVm.Phone;
        }

        var update = _authorRepository.Update(data);
        await _persistence.SaveChangesAsync();
        _genericMemoryCacheService.Remove("AuthorList");
        return new AuthorResponseVm
        {
            Id = update.Id,
            FullName = update.FullName,
            Address = update.Address,
            Phone = update.Phone,
            BirthDate = update.BirthDate
        };
    }
}