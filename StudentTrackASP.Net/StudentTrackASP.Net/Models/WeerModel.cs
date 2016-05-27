namespace StudentTrackASP.Net.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WeerModel
    {
        public string City { get; set; }

        [Range(-273, 60)]
        public decimal MinTemp { get; set; }
        [Range(-273, 60)]
        public decimal MaxTemp { get; set; }

        public override string ToString() { return $"{this.City} - min:{this.MinTemp} max:{this.MaxTemp}"; }
    }
}
