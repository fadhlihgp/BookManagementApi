using BookAuthorManagementApi.Repositories.Interfaces;
using BookAuthorManagementApi.Services.Interfaces;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorManagementApi.Controller;

[ApiController]
[Authorize]
[Route("api/v1/publisher")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpPost("get-all")]
    public async Task<IActionResult> GetAllPublishers()
    {
        var data = await _publisherService.GetAllPublishers();
        return Ok(new MultipleDataResponse
        {
            Message = "Successfully retrieved publisher data list",
            Data = data,
            TotalData = data.Count()
        });
    }

    [HttpPost("detail/{id}")]
    public async Task<IActionResult> GetPublisherById([FromRoute] string id)
    {
        var data = await _publisherService.GetPublisherById(id);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully retrieved publisher data",
            Data = data
        });
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePublisher([FromBody] PublisherRequestVm publisherRequestVm)
    {
        var data = await _publisherService.CreatePublisher(publisherRequestVm);
        return Created("api/v1/publisher/create", new SingleDataResponse
        {
            Message = "Successfully created publisher data",
            Data = data
        });
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdatePublisher([FromRoute] string id,
        [FromBody] PublisherRequestVm publisherRequestVm)
    {
        var data = await _publisherService.UpdatePublisher(id, publisherRequestVm, false);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully updated publisher data",
            Data = data
        });
    }

    [HttpPut("delete/{id}")]
    public async Task<IActionResult> DeletePublisher([FromRoute] string id)
    {
        var data = await _publisherService.UpdatePublisher(id, null, true);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully deleted publisher data",
            Data = data
        });
    }
}