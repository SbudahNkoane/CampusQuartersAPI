namespace CampusQuartersAPI.Models
{
    public class AccommodationImage
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }    
        public DateTime DateUploaded { get; set; }
        public DateTime DateTaken { get; set; }
        public Photographer? Photographer { get; set; } 

    }
}
