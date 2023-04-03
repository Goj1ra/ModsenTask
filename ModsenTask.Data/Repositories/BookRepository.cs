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

        public async Task<Book> DeleteBookAsync(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            var deletedBook = _context.Books.Remove(book).Entity;
            await _context.SaveChangesAsync();
            return deletedBook;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var list = await _context.Books.ToListAsync();
            return list;
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> GetBookByISBNAsync(string ISBN)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.ISBN == ISBN);
        }

        public async Task<Book> UpdateBookAsync(Guid id,Book book)
        {
            var originalbook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            originalbook.Author = book.Author;
            originalbook.ISBN = book.ISBN;
            originalbook.NeedBookToReturn = book.NeedBookToReturn;
            originalbook.Description = book.Description;
            originalbook.Genre = book.Genre;
            originalbook.TakenBookTime = book.TakenBookTime;
            originalbook.Name = book.Name;
            _context.Books.Update(originalbook);
            await _context.SaveChangesAsync();
            return originalbook;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
