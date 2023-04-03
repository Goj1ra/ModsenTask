using ModsenTask.Business.Models;
using ModsenTask.Business.Services.Interfaces;
using ModsenTask.Data.Entities;
using Microsoft.AspNetCore.Http;
using ModsenTask.Data.Repositories.Interfaces;
using System.Security.Claims;
using ModsenTask.Business.Mapper;

namespace ModsenTask.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        public BookService(IHttpContextAccessor httpContextAccessor, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<BookModel> CreateBook(BookModel book)
        {
            var claims = _httpContextAccessor.HttpContext.User;
            var email = claims.FindFirst(ClaimTypes.Email).Value;
            var bookToCreate = ApplicationMapper.Mapper.Map<Book>(book);
            var user = _userRepository.GetUserWithEmail(new User { Email = email }).Result;
            bookToCreate.UserId = user.Id;
            user.Books.Add(bookToCreate);
            await _bookRepository.CreateBookAsync(bookToCreate);
            _bookRepository.SaveChanges();
            return ApplicationMapper.Mapper.Map<BookModel>(bookToCreate);
        }

        public async Task<BookModel> DeleteBook(Guid id)
        {
            var bookToDelete = await _bookRepository.DeleteBookAsync(id);
            return ApplicationMapper.Mapper.Map<BookModel>(bookToDelete);
        }

        public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return ApplicationMapper.Mapper.Map<IEnumerable<BookModel>>(books);
        }

        public async Task<BookModel> GetBookById(Guid Id)
        {
            var book = await _bookRepository.GetBookByIdAsync(Id);
            return ApplicationMapper.Mapper.Map<BookModel>(book);
        }
        public async Task<BookModel> GetBookByISBN(string ISBN)
        {
            var book = await _bookRepository.GetBookByISBNAsync(ISBN);
            return ApplicationMapper.Mapper.Map<BookModel>(book);
        }

        public async Task<BookModel> UpdateBook(Guid id, BookModel book)
        {
            var bookToUpdate = ApplicationMapper.Mapper.Map<Book>(book);
            return ApplicationMapper.Mapper.Map<BookModel>(await _bookRepository.UpdateBookAsync(id,bookToUpdate));
        }
    }
}
