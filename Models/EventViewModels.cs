namespace RaceDay_Part_3_MVC.Models
{//start of namespace 
    // Used to display the list of events
    public class EventListViewModel
    {//start of clas EventListViewModel 
        public int event_id { get; set; }
        public string event_title { get; set; } = string.Empty;
        public string event_location { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string status { get; set; } = string.Empty;
        public int user_id { get; set; } // To check if the current organiser owns it
    }//end of class EventListViewModel 

    // Used when an organiser creates a new event
    public class CreateEventRequest
    {//start of class CreateEventRequest 
        public string event_title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime event_date { get; set; }
        public string event_location { get; set; } = string.Empty;
    }//end of class CreateEventRequest 
}//end of namespace 