namespace IntrogamiAPI.Models
{
    public class Following
    {
        public int FollowingId { get; set; }

        public List<User> followContainer = new();

        public List<Following> Followings = new();

        public int UserId { get; set; } // foreign key



    }
}
