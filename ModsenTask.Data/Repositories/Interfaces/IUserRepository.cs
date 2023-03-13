using ModsenTask.Data.Entities;

namespace ModsenTask.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register (User user);
        Task<User> GetUserWithEmail(User user);
    }
}
