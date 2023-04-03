namespace ModsenTask.API.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; } = new Guid();
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TakenBookTime { get; set; }
        public DateTime NeedBookToReturn { get; set; }
    }
}
