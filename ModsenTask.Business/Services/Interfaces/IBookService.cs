using ModsenTask.Business.Models;

namespace ModsenTask.Business.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookModel> CreateBook(BookModel book);
        Task<BookModel> UpdateBook(Guid id, BookModel book);
        Task<BookModel> DeleteBook(Guid Id);
        Task<BookModel> GetBookById(Guid Id);
        Task<BookModel> GetBookByISBN(string ISBN);
        Task<IEnumerable<BookModel>> GetAllBooksAsync();

    }
}
