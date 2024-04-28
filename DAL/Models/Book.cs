namespace BookStore.DAL.Models
{
    public class Book
    {
        public int bookId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int authorId { get; set; }
        public  DateTime publicationDate { get; set; }
        public string publisher { get; set; }

    }
}
