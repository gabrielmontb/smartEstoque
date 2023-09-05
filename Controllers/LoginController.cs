using Arquitetura.Classes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Okta.AspNetCore;
using Okta.Auth.Sdk;
using RestSharp;
using System.Security.Claims;
using AllowAnonymousAttribute = Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute;
using OktaDefaults = Okta.AspNetCore.OktaDefaults;

[AllowAnonymous]
public class LoginController : Controller
{
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
    public async Task<IActionResult> LogoutOld()
    {
        await HttpContext.SignOutAsync(OktaDefaults.MvcAuthenticationScheme);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");

        //v1/logout

        //HttpContext.SignOutAsync();
        //return Redirect("https://dev-10223228.okta.com/oauth2/default/v1/revoke");
        //HttpContext.SignOutAsync();
        //return Redirect("https://dev-10223228.okta.com");
        //https://dev-10223228.okta.com
        //return View();
    } 
    public async Task<IActionResult> Logout()
    {
        var URL = Util.AppSettings.OktaDomain;
        var MET = "/v1/logout?id_token_hint=00WTxSbmpz-0DDnGuYxhppP6LaukEeKw_XN_vtO1aV";
        var options = new RestClientOptions(URL)
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest(MET, Method.Get);
        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/json");
        //request.AddHeader("Authorization", "SSWS 00WTxSbmpz-0DDnGuYxhppP6LaukEeKw_XN_vtO1aV");
        RestResponse response = await client.ExecuteAsync(request);


        await HttpContext.SignOutAsync(OktaDefaults.MvcAuthenticationScheme);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");

        //v1/logout

        //HttpContext.SignOutAsync();
        //return Redirect("https://dev-10223228.okta.com/oauth2/default/v1/revoke");
        //HttpContext.SignOutAsync();
        //return Redirect("https://dev-10223228.okta.com");
        //https://dev-10223228.okta.com
        //return View();
    }
    public async Task<string> GetUser()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
//var nome = User.FindFirstValue(ClaimTypes.Name);
//var email = User.FindFirstValue(ClaimTypes.Email);
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
