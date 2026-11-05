namespace RaceDay_Part_3_MVC.Models
{
    public class ParticipantDashboardViewModel
    {
        public string Name { get; set; } = string.Empty;
        public List<ParticipantRegistrationViewModel> Registrations { get; set; } = new List<ParticipantRegistrationViewModel>();
    }

    public class ParticipantRegistrationViewModel
    {
        public int event_id { get; set; }
        public string event_title { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string category_name { get; set; } = string.Empty;
        public string registration_status { get; set; } = string.Empty;
    }

    public class ParticipantResultViewModel
    {
        public string event_title { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string category_name { get; set; } = string.Empty;
        public string finish_time { get; set; } = string.Empty;
        public int overall_rank { get; set; }
        public int total_finishers { get; set; } // To calculate "47th out of 312"
    }

    public class ProfileViewModel
    {
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string profile_picture_url { get; set; } = string.Empty; // For Azure Blob later
    }
}