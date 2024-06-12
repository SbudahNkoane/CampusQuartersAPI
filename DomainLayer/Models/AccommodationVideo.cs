namespace CampusQuartersAPI.Models
{
    public class AccommodationVideo
    {
        public int Id { get; set; }
        public string VideoURL { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime DateTaken { get; set; }
        public int? PhotographerId { get; set; }
        public Photographer? Photographer { get; set; }
    }
}
