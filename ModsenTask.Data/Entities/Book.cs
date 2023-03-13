namespace ModsenTask.Data.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime TakenBookTime { get; set; }
        public DateTime NeedBookToReturn { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
       
    }
}
