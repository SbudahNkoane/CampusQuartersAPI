namespace CampusQuartersAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
