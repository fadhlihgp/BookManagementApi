using System.Collections;
using BookAuthorManagementApi.Entities;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;

namespace BookAuthorManagementApi.Services.Interfaces;

public interface IPublisherService
{
    Task<Publisher> CreatePublisher(PublisherRequestVm publisherRequestVm);
    Task<IEnumerable<PublisherResponseVm>> GetAllPublishers();
    Task<PublisherResponseVm> GetPublisherById(string id);
    Task<Publisher> GetPublisherByIdOri(string id);
    Task<Publisher> UpdatePublisher(string id, PublisherRequestVm? publisherRequestVm, bool isDelete);
}