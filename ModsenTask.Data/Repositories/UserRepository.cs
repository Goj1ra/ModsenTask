using Microsoft.EntityFrameworkCore;
using ModsenTask.Data.Data;
using ModsenTask.Data.Entities;
using ModsenTask.Data.Repositories.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ModsenTask.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserWithEmail(User user)
        {
            var userWithEmail = _context.Users.FindAsync(user.Email).Result;
            return userWithEmail;

        }
    }
}
