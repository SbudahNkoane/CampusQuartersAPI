namespace CampusQuartersAPI.Models
{
    public class AccommodationBooking
    {
        public int Id { get; set; }
        public Student? Student { get; set; }
        public Accommodation? Accommodation { get; set; }
        public DateTime BookedAt { get; set; }
        public bool IsTaken { get; set; } = false;
        public bool IsViewed { get; set; }=false;
        public DateTime? ViewDate { get; set; }
    }
}
