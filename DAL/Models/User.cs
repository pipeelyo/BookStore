namespace BookStore.DAL.Models
{
    public class User
    {
        public int userId { get; set; }
        public required string firstName { get; set; }
        public string lastName { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public required string rol { get; set; }
        public DateTime creationDate { get; set; }
    }

}
