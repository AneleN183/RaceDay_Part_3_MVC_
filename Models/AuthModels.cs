namespace RaceDay_Part_3_MVC.Models
{
    public class LoginRequest
    {
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    public class RegisterRequest
    {
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string user_role { get; set; } = "participant"; // default
    }

    public class UserResponse
    {
        public int user_id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string user_role { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string message { get; set; } = string.Empty;
        public UserResponse user { get; set; } = new UserResponse();
    }
}