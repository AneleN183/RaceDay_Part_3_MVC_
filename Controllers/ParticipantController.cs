using Microsoft.AspNetCore.Mvc;
using RaceDay_Part_3_MVC.Filters;
using RaceDay_Part_3_MVC.Models;
using RaceDay_Part_3_MVC.Services;

namespace RaceDay_Part_3_MVC.Controllers
{
    [SessionAuthorize]
    public class ParticipantController : Controller
    {
        private readonly ApiService _apiService;

        public ParticipantController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: /Participant/Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserRole") != "participant")
                return RedirectToAction("Index", "Events");

            var model = new ParticipantDashboardViewModel
            {
                Name = HttpContext.Session.GetString("UserName") ?? "Participant",
                Registrations = new List<ParticipantRegistrationViewModel>
                {
                    new ParticipantRegistrationViewModel { event_id = 1, event_title = "Comrades Marathon", event_date = new DateTime(2026, 6, 1), category_name = "90km Ultra", registration_status = "confirmed" },
                    new ParticipantRegistrationViewModel { event_id = 2, event_title = "Cape Town Cycle Tour", event_date = new DateTime(2026, 3, 8), category_name = "109km Cycle", registration_status = "pending" }
                }
            };

            return View(model);
        }

        // POST: /Participant/Enrol/1
        [HttpPost]
        public IActionResult Enrol(int eventId, int categoryId)
        {
            if (HttpContext.Session.GetString("UserRole") != "participant")
                return RedirectToAction("Index", "Events");

            // In reality: call API to POST api/registrations
            TempData["Success"] = "Successfully enrolled in the event!";
            return RedirectToAction("Dashboard");
        }

        // GET: /Participant/MyResults
        public IActionResult MyResults()
        {
            if (HttpContext.Session.GetString("UserRole") != "participant")
                return RedirectToAction("Index", "Events");

            var results = new List<ParticipantResultViewModel>
            {
                new ParticipantResultViewModel { event_title = "Comrades Marathon", event_date = new DateTime(2025, 6, 1), category_name = "90km Ultra", finish_time = "05:30:45", overall_rank = 47, total_finishers = 312 },
                new ParticipantResultViewModel { event_title = "Soweto Marathon", event_date = new DateTime(2024, 11, 2), category_name = "42km Run", finish_time = "03:45:20", overall_rank = 150, total_finishers = 800 }
            };

            return View(results);
        }

        // GET: /Participant/Profile
        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("UserRole") != "participant")
                return RedirectToAction("Index", "Events");

            var profile = new ProfileViewModel
            {
                first_name = "John",
                last_name = "Doe",
                email = "john@test.com"
            };

            return View(profile);
        }

        // POST: /Participant/Profile
        [HttpPost]
        public IActionResult Profile(ProfileViewModel model)
        {
            // In reality: call API to update profile
            TempData["Success"] = "Profile updated successfully!";
            return RedirectToAction("Profile");
        }
    }
}