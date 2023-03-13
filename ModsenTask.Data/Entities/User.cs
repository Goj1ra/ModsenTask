using Microsoft.AspNetCore.Identity;

namespace ModsenTask.Data.Entities
{
    public class User 
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
