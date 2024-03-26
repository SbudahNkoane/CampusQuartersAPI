namespace CampusQuartersAPI.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<AccommodationImage> Images { get; set; }
        public List<AccommodationVideo> Videos { get; set; }
        public AccommodationType Type { get; set; }
        public Availability Availability { get; set; }
        public Landlord Landlord { get; set; }
        public DateTime Photographed { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public double Deposit { get; set; }
        public double Rent { get; set; }
        public string Name { get; set; }    
    }
}
