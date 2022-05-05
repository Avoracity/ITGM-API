namespace IntrogamiAPI.Models
{
    public class Response
    {
        public int StatusCode;
        public string? StatusDesc;

        public List<User>? UserResponse = new();
        public List<Origami>? OrigamiResponse = new();
        public List<Following>? FollowingResponse = new();


    }
}
