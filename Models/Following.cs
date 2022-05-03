namespace IntrogamiAPI.Models
{
    public class Following
    {
        public int FollowingId { get; set; }

        public List<User> followContainer = new();

       public int UserId { get; set; }

    }
}
