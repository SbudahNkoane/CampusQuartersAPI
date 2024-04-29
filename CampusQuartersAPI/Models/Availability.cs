namespace CampusQuartersAPI.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public int? StatusId { get; set; }
        public AvailabilityStatus? Status { get; set; }
        public DateTime? DateAvailable { get; set; } 
    }
}
