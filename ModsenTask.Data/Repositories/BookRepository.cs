using Microsoft.EntityFrameworkCore;
using ModsenTask.Data.Data;
using ModsenTask.Data.Entities;
using ModsenTask.Data.Repositories.Interfaces;

namespace ModsenTask.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return _context.Entry(book).Entity;
        }

        public async Task<Book> DeleteBookAsync(Book book)
        {
            
            var deletedBook = _context.Books.Remove(book).Entity;
            await _context.SaveChangesAsync();
            return deletedBook;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(x => x.Author).Include(x => x.Genre).ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> GetBookByISBNAsync(string ISBN)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.ISBN == ISBN);
        }

        public async Task<Book> UpdateBookAsync(Book bookToUpdate, Book updatedBook)
        {
            _context.Entry(bookToUpdate).CurrentValues
                .SetValues(updatedBook);
            await _context.SaveChangesAsync();
            return _context.Entry(bookToUpdate).Entity;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
