namespace StudentTrackASP.Net.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Buddy
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0,150)]
        public int Age { get; set; }

        public string Location { get; set; }

        public int? Huisnummer { get; set; }

    }
}
