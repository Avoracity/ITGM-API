namespace IntrogamiAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }

        public int OrigamiId { get; set; } // foreign key

        public List<User> Users = new();



    }
}
