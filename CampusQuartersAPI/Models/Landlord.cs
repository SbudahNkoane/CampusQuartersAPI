namespace CampusQuartersAPI.Models
{
    public class Landlord:User
    {
        public List<Accommodation>  Accommodations { get; set; }
    }
}
