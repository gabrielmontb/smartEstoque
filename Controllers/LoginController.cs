using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Mvc;
using Okta.Auth.Sdk;

using AllowAnonymousAttribute = Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute;
using Okta.Sdk.Abstractions;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly IOktaClient _oktaClient;
    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("CustomCallback", "Account")
            });
        }
    }
    public void Logout()
    {
        HttpContext.SignOutAsync();
        //return Redirect("https://dev-10223228.okta.com/oauth2/default/v1/revoke");
        //HttpContext.SignOutAsync();
        //return Redirect("https://dev-10223228.okta.com");
        //https://dev-10223228.okta.com
        //return View();
    }
}
//var nome = User.FindFirstValue(ClaimTypes.Name);
//var email = User.FindFirstValue(ClaimTypes.Email);
//var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
//var permissao = User.FindFirstValue(ClaimTypes.Role);
//var nomeShort = User.FindFirstValue(ClaimTypes.GivenName);





//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace SmartEstoque.Controllers
//{
//    [AllowAnonymous]
//    public class LoginController : Controller
//    {
//        [HttpGet("Login")]
//        public IActionResult Login()
//        {
//            //var redirectUrl = returnUrl is null ? Url.Content("~/") : "/" + returnUrl;

//            if (User.Identity.IsAuthenticated)
//            {
//                return LocalRedirect("/Home");
//            }
//            return Challenge();
//        }
//        [HttpGet("Logout")]
//        public async Task<ActionResult> Logout([FromQuery] string returnUrl)
//        {
//            var redirectUrl = returnUrl is null ? Url.Content("~/") : "/" + returnUrl;
//            if (User.Identity.IsAuthenticated)
//            {
//                return LocalRedirect(redirectUrl);
//            }
//            await HttpContext.SignOutAsync();
//            return LocalRedirect(redirectUrl);
//        }

//    }
//}
