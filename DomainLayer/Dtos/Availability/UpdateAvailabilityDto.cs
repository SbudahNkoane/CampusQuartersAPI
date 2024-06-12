namespace CampusQuartersAPI.Dtos.Availability
{
    public class UpdateAvailabilityDto
    {
        public bool IsAvailable { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateAvailable { get; set; }
    }
}
