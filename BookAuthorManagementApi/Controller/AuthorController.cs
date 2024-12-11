using BookAuthorManagementApi.Services.Interfaces;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorManagementApi.Controller;

[ApiController]
[Authorize]
[Route("api/v1/author")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost("get-all")]
    public async Task<IActionResult> GetAllAuthors()
    {
        var data = await _authorService.GetAllAuthors();
        return Ok(new MultipleDataResponse
        {
            Message = "Successfully retrieved data",
            Data = data,
            TotalData = data.Count()
        });
    }

    [HttpPost("detail/{id}")]
    public async Task<IActionResult> GetAuthorById([FromRoute] string id)
    {
        var data = await _authorService.GetAuthorById(id);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully retrieved author data",
            Data = data
        });
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorRequestVm authorRequestVm)
    {
        var data = await _authorService.CreateAuthorAsync(authorRequestVm);
        return Created("api/v1/author", new SingleDataResponse
        {
            Message = "Successfully created author",
            Data = data
        });
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAuthor([FromRoute] string id, [FromBody] AuthorRequestVm authorRequestVm)
    {
        var data = await _authorService.UpdateAuthor(id, authorRequestVm);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully updated author data",
            Data = data
        });
    }
    
    [HttpPut("delete/{id}")]
    public async Task<IActionResult> DeleteAuthor([FromRoute] string id)
    {
        var data = await _authorService.UpdateAuthor(id, null, true);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully deleted author data",
            Data = data
        });
    }
}