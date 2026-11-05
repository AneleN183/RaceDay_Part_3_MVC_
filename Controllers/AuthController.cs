using Microsoft.AspNetCore.Mvc;
using RaceDay_Part_3_MVC.Models;
using RaceDay_Part_3_MVC.Services;

namespace RaceDay_Part_3_MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApiService _apiService;

        public AuthController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        // [HttpPost]
        //public async Task<IActionResult> Login(LoginRequest request)
        //{
        // 1. Call the API
        // var response = await _apiService.PostAsync<LoginRequest, LoginResponse>("api/auth/login", request);

        // 2. If successful, save session and redirect
        //if (response != null && response.user != null)
        //{
        //HttpContext.Session.SetInt32("UserId", response.user.user_id);
        // HttpContext.Session.SetString("UserRole", response.user.user_role);
        //HttpContext.Session.SetString("UserName", response.user.first_name);

        // Redirect based on role
        //if (response.user.user_role == "organiser")
        //return RedirectToAction("Index", "Events"); // Organiser dashboard
        //else
        //return RedirectToAction("Index", "Events"); // Participant dashboard
        //}

        // 3. If failed, show error
        //ViewBag.Error = "Invalid email or password.";
        //return View(request);
        //}
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            // TEMPORARY FAKE LOGIN (For UI Demo)
            if (request.email == "admin@org.com")
            {
                HttpContext.Session.SetInt32("UserId", 1);
                HttpContext.Session.SetString("UserRole", "organiser");
                HttpContext.Session.SetString("UserName", "Thabo (Organiser)");
                return RedirectToAction("Index", "Events");
            }
            else if (request.email == "user@test.com")
            {
                HttpContext.Session.SetInt32("UserId", 2);
                HttpContext.Session.SetString("UserRole", "participant");
                HttpContext.Session.SetString("UserName", "John (Participant)");
                return RedirectToAction("Index", "Events");
            }

            ViewBag.Error = "Invalid email or password. (Use admin@org.com or user@test.com)";
            return View(request);
        }
        // GET: /Auth/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var success = await _apiService.PostAsync("api/auth/register", request);

            if (success)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Error = "Registration failed. Email might already exist.";
            return View(request);
        }

        // POST: /Auth/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}