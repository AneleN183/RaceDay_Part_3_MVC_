using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RaceDay_Part_3_MVC.Filters
{//start of namespace 
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {//start of class
        public override void OnActionExecuting(ActionExecutingContext context)
        {//start of method 
            var userId = context.HttpContext.Session.GetInt32("UserId");

            // If no user ID in session, kick them to the Login page
            if (userId == null)
            {//start of if 
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }//end of if 
        }//end of method 
    }//end of class
}//end of namespace 