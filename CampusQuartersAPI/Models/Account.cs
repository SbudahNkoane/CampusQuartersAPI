namespace CampusQuartersAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
