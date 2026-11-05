namespace RaceDay_Part_3_MVC.Models
{
    // Used to display the list of events
    public class EventListViewModel
    {
        public int event_id { get; set; }
        public string event_title { get; set; } = string.Empty;
        public string event_location { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string status { get; set; } = string.Empty;
        public int user_id { get; set; } // To check if the current organiser owns it
    }

    // Used when an organiser creates a new event
    public class CreateEventRequest
    {
        public string event_title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string event_location { get; set; } = string.Empty;
    }
}