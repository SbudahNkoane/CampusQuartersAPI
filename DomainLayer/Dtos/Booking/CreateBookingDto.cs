namespace CampusQuartersAPI.Dtos.Booking
{
    public class CreateBookingDto
    {
        public int? StudentId { get; set; }
        public int? AccommodaitonId { get; set; }
        public DateTime BookedAt { get; set; } = DateTime.Now;
        public bool IsTaken { get; set; } = false;
        public bool IsViewed { get; set; } = false;
        public DateTime? ViewDate { get; set; }
    }
}
