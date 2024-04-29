namespace CampusQuartersAPI.Dtos.Booking
{
    public class UpdateBookingDto
    {
        public bool IsTaken { get; set; } 
        public bool IsViewed { get; set; } 
        public DateTime? ViewDate { get; set; }
    }
}
