namespace ModsenTask.Business.Models
{
    public class UserModel
    {
        public Guid Id { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Token { get; set; }
    }
}
