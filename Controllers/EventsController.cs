
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaceDay_Part_3_MVC.Filters;
using RaceDay_Part_3_MVC.Models;
using RaceDay_Part_3_MVC.Services;

namespace RaceDay_Part_3_MVC.Controllers
{//start of namespace 
    [SessionAuthorize] // Protect the whole controller
    public class EventsController : Controller
    {//start of class
        private readonly ApiService _apiService;

        public EventsController(ApiService apiService)
        {//start of constructor 
            _apiService = apiService;
        }//end of constructor 

        // GET: /Events (Public List - used by Participants)
        [AllowAnonymous] // Allow participants/guests to see this
        public async Task<IActionResult> Index()
        {//start of method 
            // MOCK DATA FOR DEMO
            var events = new List<EventListViewModel>
            {
                new EventListViewModel { event_id = 1, event_title = "Comrades Marathon", event_location = "PMB to Durban", event_date = new DateTime(2026, 6, 1), status = "upcoming" },
                new EventListViewModel { event_id = 2, event_title = "Cape Town Cycle Tour", event_location = "Cape Town", event_date = new DateTime(2026, 3, 8), status = "upcoming" }
            };
            return View(events);
        }//end of method 

        // GET: /Events/Dashboard (Organiser Only)
        public IActionResult Dashboard()
        {//start of method 
            if (HttpContext.Session.GetString("UserRole") != "organiser")
                return RedirectToAction("Index");

            // MOCK DATA FOR DEMO
            var dashboard = new OrganiserDashboardViewModel
            {
                OrganiserName = HttpContext.Session.GetString("UserName") ?? "Organiser",
                TotalEvents = 2,
                TotalEnrolments = 1450,
                Events = new List<EventSummaryViewModel>
                {
                    new EventSummaryViewModel { event_id = 1, event_title = "Comrades Marathon", event_date = new DateTime(2026, 6, 1), status = "upcoming", enrolment_count = 1200 },
                    new EventSummaryViewModel { event_id = 2, event_title = "Cape Town Cycle Tour", event_date = new DateTime(2026, 3, 8), status = "upcoming", enrolment_count = 250 }
                }
            };

            return View(dashboard);
        }//end of method 

        // GET: /Events/Enrolments/1 (Organiser Only)
        public IActionResult Enrolments(int id)
        {//start of method 
            if (HttpContext.Session.GetString("UserRole") != "organiser")
                return RedirectToAction("Index");

            // MOCK DATA FOR DEMO
            var enrolments = new List<EnrolmentViewModel>
            {
                new EnrolmentViewModel { registration_id = 1, participant_name = "John Doe", category_name = "90km Ultra", registration_status = "confirmed" },
                new EnrolmentViewModel { registration_id = 2, participant_name = "Mary Smith", category_name = "45km Half", registration_status = "pending" }
            };

            ViewBag.EventTitle = "Comrades Marathon";
            ViewBag.EventId = id;
            return View(enrolments);
        }//end of method 

        // GET: /Events/EnterResults/1 (Organiser Only)
        public IActionResult EnterResults(int id)
        {//start of method 
            if (HttpContext.Session.GetString("UserRole") != "organiser")
                return RedirectToAction("Index");

            // MOCK DATA FOR DEMO
            var results = new List<ResultEntryViewModel>
            {
                new ResultEntryViewModel { registration_id = 1, participant_name = "John Doe", finish_time = "05:30:00", overall_rank = 150 },
                new ResultEntryViewModel { registration_id = 2, participant_name = "Mary Smith", finish_time = "", overall_rank = 0 }
            };

            ViewBag.EventTitle = "Comrades Marathon";
            return View(results);
        }//end of method 

        // GET: /Events/Create (Organiser Only)
        public IActionResult Create()
        {//start of method 
            if (HttpContext.Session.GetString("UserRole") != "organiser")
                return RedirectToAction("Index");

            return View();
        }//end of method 

        // POST: /Events/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateEventRequest request, IFormFile bannerFile)
        {//start of method 
            if (HttpContext.Session.GetString("UserRole") != "organiser")
                return RedirectToAction("Index");

            // --- REAL API CALL (Ideally, you would send this to the API) ---
            // using var content = new MultipartFormDataContent();
            // content.Add(new StreamContent(bannerFile.OpenReadStream()), "file", bannerFile.FileName);
            // await _httpClient.PostAsync($"api/events/{eventId}/upload-banner", content);

            // --- MOCK DEMO ---
            // For your demo, we just pretend the upload succeeded.
            if (bannerFile != null && bannerFile.Length > 0)
            {//start of if 
                TempData["Success"] = "Event created and banner uploaded to Azure Blob Storage successfully! (Mock)";
            }//end of if 
            else
            {//start of else
                TempData["Success"] = "Event created successfully! (No banner uploaded)";
            }//end of else 

            return RedirectToAction("Dashboard");
        }//end of method 

    }//end of class
}//end of namespace 