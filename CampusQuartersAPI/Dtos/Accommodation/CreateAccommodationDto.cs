using CampusQuartersAPI.Dtos.Availability;

namespace CampusQuartersAPI.Dtos.Accommodation
{
    public class CreateAccommodationDto
    {
        public string Description { get; set; }
        public double Deposit { get; set; }
        public double Rent { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? TypeId { get; set; }
        public CreateAvailabilityDto Availability { get; set; }
        public int? LandlordId { get; set; }
    }
}
