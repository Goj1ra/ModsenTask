using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModsenTask.API.Mapper;
using ModsenTask.API.ViewModels;
using ModsenTask.Business.Mapper;
using ModsenTask.Business.Models;
using ModsenTask.Business.Services.Interfaces;
using System.Text.Json;

namespace ModsenTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Route("~/api/CreateBook")]
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookViewModel bookViewModel)
        {
            try
            {
                var book = ApiMapper.Mapper.Map<BookModel>(bookViewModel);
                var response = await _bookService.CreateBook(book);
                var apiResult = ApiResult<BookModel>.Success(response);
                return Ok(apiResult);
            }
            catch(Exception ex)
            {
                var apiResult = ApiResult<BookModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }

        [Route("~/api/DeleteBook")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBook([FromBody] BookViewModel bookViewModel)
        {
            try
            {
                var book = ApiMapper.Mapper.Map<BookModel>(bookViewModel);
                var response = await _bookService.DeleteBook(book.Id);
                var apiResult = ApiResult<BookModel>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<BookModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
            
        }

        [Route("~/api/GetAllBooks")]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var response = await _bookService.GetAllBooksAsync();
                var apiResult = ApiResult<IEnumerable<BookModel>>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<BookModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }

        [Route("~/api/GetBookById")]
        [HttpGet]
        public async Task<IActionResult> GetBookById([FromBody] BookViewModel bookViewModel)
        {
            try
            {
                var book = ApiMapper.Mapper.Map<BookModel>(bookViewModel);
                var response = await _bookService.GetBookById(book.Id);
                var apiResult = ApiResult<BookModel>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<BookModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }

        [Route("~/api/GetBookByISBN")]
        [HttpGet]
        public async Task<IActionResult> GetBookByISBN([FromBody] BookViewModel bookViewModel)
        {
            try
            {
                var book = ApplicationMapper.Mapper.Map<BookModel>(bookViewModel);
                var response = await _bookService.GetBookByISBN(book.ISBN);
                var apiResult = ApiResult<BookModel>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<BookModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }

        [Route("~/api/UpdateBook")]
        [HttpPut]
        public async Task<IActionResult> UpdateBook(Guid Id, [FromBody] BookViewModel bookViewModel)
        {
            try
            {
                var book = ApiMapper.Mapper.Map<BookModel>(bookViewModel);
                var response = await _bookService.UpdateBook(Id, book);
                var apiResult = ApiResult<BookModel>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<BookModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }
    }
}
