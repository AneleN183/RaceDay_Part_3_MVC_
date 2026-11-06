namespace RaceDay_Part_3_MVC.Models
{//start of namespace 
    public class ParticipantDashboardViewModel
    {//start of class ParticipantDashboardViewModel 
        public string Name { get; set; } = string.Empty;
        public List<ParticipantRegistrationViewModel> Registrations { get; set; } = new List<ParticipantRegistrationViewModel>();
    }//end of class ParticipantDashboardViewModel 

    public class ParticipantRegistrationViewModel
    {//start of class ParticipantRegistrationViewModel 
        public int event_id { get; set; }
        public string event_title { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string category_name { get; set; } = string.Empty;
        public string registration_status { get; set; } = string.Empty;
    }//end of class ParticipantRegistrationViewModel 

    public class ParticipantResultViewModel
    {//start of class ParticipantResultViewModel 
        public string event_title { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string category_name { get; set; } = string.Empty;
        public string finish_time { get; set; } = string.Empty;
        public int overall_rank { get; set; }
        public int total_finishers { get; set; } // To calculate "47th out of 312"
    }//end of class ParticipantResultViewModel 

    public class ProfileViewModel
    {//start of class ProfileViewModel 
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string profile_picture_url { get; set; } = string.Empty; // For Azure Blob later
    }//end of class ProfileViewModel 
}//end of namespace 