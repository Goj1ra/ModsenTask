using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsenTask.Business.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TakenBookTime { get; set; }
        public DateTime NeedBookToReturn { get; set; }
    }
}
