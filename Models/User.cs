namespace IntrogamiAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public Origami? Origami { get; set; }
        public Following? Following { get; set; }
    }
}
