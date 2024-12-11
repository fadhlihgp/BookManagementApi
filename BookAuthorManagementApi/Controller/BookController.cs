using BookAuthorManagementApi.Entities;
using BookAuthorManagementApi.Services.Interfaces;
using BookAuthorManagementApi.ViewModels.Requests;
using BookAuthorManagementApi.ViewModels.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorManagementApi.Controller;

[ApiController]
[Authorize]
[Route("api/v1/book")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("get-all")]
    public async Task<IActionResult> GetAllBooks()
    {
        var data = await _bookService.GetAllBooksAsync();
        return Ok(new MultipleDataResponse
        {
            Message = "Successfully get all books",
            Data = data,
            TotalData = data.Count()
        });
    }

    [HttpPost("detail/{id}")]
    public async Task<IActionResult> GetBookById([FromRoute] string id)
    {
        var data = await _bookService.GetBookByIdAsync(id);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully get book detail",
            Data = data,
        });
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateBookAsync([FromBody] BookRequestVm bookRequestVm)
    {
        var data = await _bookService.CreateBookAsync(bookRequestVm);
        return Created("api/v1/book/create", new SingleDataResponse
        {
            Message = "Successfully create book",
            Data = data
        });
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateBook([FromRoute] string id, [FromBody] BookRequestVm bookRequestVm)
    {
        var data = await _bookService.UpdateBook(id, bookRequestVm);
        return Ok(new SingleDataResponse
        {
            Message = "Successfully update book",
            Data = data
        });
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteBook(string id)
    {
        await _bookService.DeleteBook(id);
        return Ok(new NoDataResponse
        {
            Message = "Successfully delete book"
        });
    }
}