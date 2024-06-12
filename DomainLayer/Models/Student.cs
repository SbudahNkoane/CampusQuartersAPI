namespace CampusQuartersAPI.Models
{
    public class Student:User
    {
        public  int StudentNumber { get; set; }
        public List<AccommodationBooking>? Bookings { get; set; }    
    }
}
