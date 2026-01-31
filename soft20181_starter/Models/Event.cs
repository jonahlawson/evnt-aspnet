using System.ComponentModel.DataAnnotations;

namespace soft20181_starter.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public string VideoPath { get; set; }

        [Required]
        public string Website { get; set; }
    }
}
