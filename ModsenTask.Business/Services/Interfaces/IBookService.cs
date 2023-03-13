using ModsenTask.Business.Models;
using ModsenTask.Data.Entities;

namespace ModsenTask.Business.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookModel> CreateBook(BookModel book);
        Task<BookModel> UpdateBook(Guid bookToUpdateId, BookModel book);
        Task<BookModel> DeleteBook(Guid Id);
        Task<BookModel> GetBookById(Guid Id);
        Task<BookModel> GetBookByISBN(string ISBN);
        Task<IEnumerable<BookModel>> GetAllBooksAsync();

    }
}
