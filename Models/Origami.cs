namespace IntrogamiAPI.Models
{
    public class Origami
    {
        public int OrigamiId { get; set; }
        public string? NameOfOrigami { get; set; }
        public string? DescOrigami { get; set; }

        public User? User { get; set; }

    }
}
