namespace CampusQuartersAPI.Dtos.Availability
{
    public class AvailabilityDto
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateAvailable { get; set; }
    }
}
