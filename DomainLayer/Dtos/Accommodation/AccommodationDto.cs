using CampusQuartersAPI.Dtos.Availability;
using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Models;

namespace CampusQuartersAPI.Dtos.Accommodation
{
    public class AccommodationDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int? TypeId { get; set; }
        public int? AvailabilityId { get; set; }
        
        public int? LandlordId { get; set; }
       
        public DateTime? Photographed { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public double Deposit { get; set; }
        public double Rent { get; set; }
        public string Name { get; set; }
        public List<AccommodationImage>? Images { get; set; }
        public List<AccommodationVideo>? Videos { get; set; }
    }
}
