namespace RaceDay_Part_3_MVC.Models
{
    public class OrganiserDashboardViewModel
    {
        public string OrganiserName { get; set; } = string.Empty;
        public int TotalEvents { get; set; }
        public int TotalEnrolments { get; set; }
        public List<EventSummaryViewModel> Events { get; set; } = new List<EventSummaryViewModel>();
    }

    public class EventSummaryViewModel
    {
        public int event_id { get; set; }
        public string event_title { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string status { get; set; } = string.Empty;
        public int enrolment_count { get; set; } // How many people joined
        public string banner_image_url { get; set; } = string.Empty;
    }

    public class EnrolmentViewModel
    {
        public int registration_id { get; set; }
        public string participant_name { get; set; } = string.Empty;
        public string category_name { get; set; } = string.Empty;
        public string registration_status { get; set; } = string.Empty;
    }

    // Used for Results entry
    public class ResultEntryViewModel
    {
        public int registration_id { get; set; }
        public string participant_name { get; set; } = string.Empty;
        public string finish_time { get; set; } = string.Empty; // e.g., "05:30:00"
        public int overall_rank { get; set; }
    }
}