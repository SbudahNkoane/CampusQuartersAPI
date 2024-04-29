namespace CampusQuartersAPI.Dtos.Booking
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? AccommodaitonId { get; set; }
        public DateTime BookedAt { get; set; }
        public bool IsTaken { get; set; }
        public bool IsViewed { get; set; } 
        public DateTime? ViewDate { get; set; }
    }
}
