namespace MVCCore.Models
{
    public class Users
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Roles
    {
        public string RoleId { get; set; }
        public string Role { get; set; }

    }
    public class UserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
