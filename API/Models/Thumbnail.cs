namespace API.Models
{
  public class Thumbnail
    {
        public int Id { get; set; }
        public string Tiny { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }

        // Propriedade de navega��o
        public Clip Clip { get; set; }
  }
}