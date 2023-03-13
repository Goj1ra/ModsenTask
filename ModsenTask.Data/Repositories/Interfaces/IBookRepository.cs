using ModsenTask.Data.Entities;

namespace ModsenTask.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> GetBookByISBNAsync(string ISBN);
        Task<Book> UpdateBookAsync (Book bookToUpdate, Book updatedBook);
        Task<Book> DeleteBookAsync (Book id);
        void SaveChanges();
    }
}
