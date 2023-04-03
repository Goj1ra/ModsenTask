using ModsenTask.Business.Models;

namespace ModsenTask.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Register(UserModel user);
        Task<UserModel> Login (UserModel user);
    }
}
