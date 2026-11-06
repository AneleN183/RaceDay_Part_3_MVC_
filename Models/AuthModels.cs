namespace RaceDay_Part_3_MVC.Models
{//start of namespace 
    public class LoginRequest
    {//start of class LoginRequest
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }//end of class LoginRequest 

    public class RegisterRequest
    {//beginning of class RegisterRequest 
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string user_role { get; set; } = "participant"; // default
    }//end of class RegisterRequest 

    public class UserResponse
    {//start of class UserResponse 
        public int user_id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string user_role { get; set; } = string.Empty;
    }//end of class UserResponse 

    public class LoginResponse
    {//beginning of class LoginResponse 
        public string message { get; set; } = string.Empty;
        public UserResponse user { get; set; } = new UserResponse();
    }//end of class LoginResponse
}//end of namespace 