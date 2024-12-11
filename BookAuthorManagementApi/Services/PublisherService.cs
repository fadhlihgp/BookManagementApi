using BookAuthorManagementApi.Context;
using BookAuthorManagementApi.Entities;
using BookAuthorManagementApi.Exceptions;
using BookAuthorManagementApi.Repositories.Interfaces;
using BookAuthorManagementApi.Services.Interfaces;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;

namespace BookAuthorManagementApi.Services;

public class PublisherService : IPublisherService
{
    private readonly IRepository<Publisher> _publisherRepository;
    private readonly IGenericMemoryCacheService _genericMemoryCacheService;
    private readonly IPersistence _persistence;
    private readonly string _cacheKey = "PublisherList";

    public PublisherService(IPersistence persistence, IGenericMemoryCacheService genericMemoryCacheService, IRepository<Publisher> publisherRepository)
    {
        _persistence = persistence;
        _genericMemoryCacheService = genericMemoryCacheService;
        _publisherRepository = publisherRepository;
    }

    public async Task<Publisher> CreatePublisher(PublisherRequestVm publisherRequestVm)
    {
        var publisher = new Publisher
        {
            Name = publisherRequestVm.Name,
            Address = publisherRequestVm.Address,
            Phone = publisherRequestVm.Phone
        };
        var save = await _publisherRepository.Save(publisher);
        await _persistence.SaveChangesAsync();
        _genericMemoryCacheService.Remove(_cacheKey);
        return save;
    }

    public async Task<IEnumerable<PublisherResponseVm>> GetAllPublishers()
    {
        return await _genericMemoryCacheService.GetOrCreate(_cacheKey, async () =>
        {
            var publishers = await _publisherRepository.FindAll(publisher => !publisher.IsDeleted);
            return publishers.Select(publisher => new PublisherResponseVm
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Address = publisher.Address,
                Phone = publisher.Phone,
                Books = publisher.Books.Select(book => new BookResponseVm
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
                        Id = publisher.Id,
                        Name = publisher.Name,
                        Address = publisher.Address,
                        Phone = publisher.Phone
                    }
                })
            });
        });
    }

    public async Task<PublisherResponseVm> GetPublisherById(string id)
    {
        var data = await GetPublisherByIdOri(id);
        return new PublisherResponseVm
        {
            Id = data.Id,
            Name = data.Name,
            Address = data.Address,
            Phone = data.Phone,
            Books = data.Books.Select(book => new BookResponseVm
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
                    Id = data.Id,
                    Name = data.Name,
                    Address = data.Address,
                    Phone = data.Phone,
                }
            })
        };
    }

    public async Task<Publisher> GetPublisherByIdOri(string id)
    {
        var data = await _publisherRepository.Find(publisher => publisher.Id.Equals(id) && !publisher.IsDeleted);
        if (data == null) throw new NotFoundException("Publisher not found");
        return data;
    }

    public async Task<Publisher> UpdatePublisher(string id, PublisherRequestVm? publisherRequestVm, bool isDelete)
    {
        var data = await GetPublisherByIdOri(id);
        if (isDelete)
        {
            data.IsDeleted = true;
        }
        else
        {
            if (publisherRequestVm == null) throw new BadRequestException("Form publisher must not be blank");
            data.Name = publisherRequestVm.Name;
            data.Address = publisherRequestVm.Address;
            data.Phone = publisherRequestVm.Phone;
        }

        var publisher = _publisherRepository.Update(data);
        await _persistence.SaveChangesAsync();
        _genericMemoryCacheService.Remove(_cacheKey);
        return new Publisher
        {
            Id = publisher.Id,
            Address = publisher.Address,
            Phone = publisher.Phone,
            Name = publisher.Name
        };
    }
}