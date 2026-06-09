namespace UserAuthApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_name { get; set; } = string.Empty;
        public string Last_name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone_number { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}