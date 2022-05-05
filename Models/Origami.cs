namespace IntrogamiAPI.Models
{
    public class Origami
    {
        public int OrigamiId { get; set; }
        public string? OrigamiName { get; set; }
        public string? OrigamiDesc { get; set; }
  
        public List<Origami> Origamis = new();

    }
}
