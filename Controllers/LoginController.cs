using Arquitetura.Classes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Okta.AspNetCore;
using Okta.Auth.Sdk;
using RestSharp;
using System.Security.Claims;
using System.Web.Http;
using AllowAnonymousAttribute = Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using OktaDefaults = Okta.AspNetCore.OktaDefaults;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

[Authorize]
public class LoginController : Controller
{
    public IActionResult Login()
    {
        if (!HttpContext.User.Identity.IsAuthenticated)
        {
            return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
        }

        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> LogoutOld()
    {
        await HttpContext.SignOutAsync(OktaDefaults.MvcAuthenticationScheme);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    } 
    public async Task<IActionResult> Logout2()
    {

        //return new SignOutResult(new[] { OpenIdConnectDefaults.AuthenticationScheme, CookieAuthenticationDefaults.AuthenticationScheme });

        var token = HttpContext.GetTokenAsync("id_token");
        var URL = Util.AppSettings.OktaDomain;
        var MET = "/v1/logout?id_token_hint=" + "eyJraWQiOiJLM1BTcFpqVGxwc0FJS1NDUGdadHF5clNxMk1INDZwNV92UmlfbGJNOVNFIiwiYWxnIjoiUlMyNTYifQ.eyJ2ZXIiOjEsImp0aSI6IkFULkxoMzNYQnI2Z1pZdXJoWEZYR2k3S21xcTRWZW9jS2RjOUdCOE5sajJpV00iLCJpc3MiOiJodHRwczovL2Rldi0xMDIyMzIyOC5va3RhLmNvbS9vYXV0aDIvZGVmYXVsdCIsImF1ZCI6ImFwaTovL2RlZmF1bHQiLCJpYXQiOjE2OTM5NDc3MDAsImV4cCI6MTY5Mzk1MTMwMCwiY2lkIjoiMG9hYWl3aTg0dUgzcVgzbHU1ZDciLCJ1aWQiOiIwMHVhaXFmMWFyWnA5YkNPRjVkNyIsInNjcCI6WyJlbWFpbCIsIm9wZW5pZCIsInByb2ZpbGUiXSwiYXV0aF90aW1lIjoxNjkzOTQ3Njk5LCJzdWIiOiJnYWJyaWVsLm1vbnRzZXJyYXRAYnl0ZW9uLmNvbS5iciJ9.aKVgm7OBQWZu0Tffyp_ahj9MGBWLjlFk7nY_r1nYJapcHdCXae428P8k1qY4iMvKt-Uyje79sSsYm_qb_V3h29_Cu2fKiAwb54uHWETQKW-PtU9G3d8e4q0KhtCUcwZpKmK-KdTnGi-F013QIKWUobqseBIs68W63WPh5WHU9inQgo8IPCxDzFufr4OqhJsi1jMck7n6iNvHo5fdIbKIW0nFkBmatIoMcOALXmw_0Y6RJTRw9ozocxnW_OLKTKAPO9kzIMJahoNDWdSjFI-SZC4bzVY97aAkALQ0mN48_ymxcPW8qmQRj8FtQqeLag2OUqO90wCiXEfkluyaIHAw2g";// + "id_token_hint=" + "WrE05Bdkf9pym6Nx04-uL9E0gWYFcjYdYEnyqnqAYRo";
        //00T18y6uayfneDHfO5d7
        var options = new RestClientOptions(URL)
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest(MET, Method.Post);
        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/json");
        RestResponse response = await client.ExecuteAsync(request);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        Response.Redirect("https://dev-10223228.okta.com/oauth2/default/v1/authorize?client_id=0oaaiwi84uH3qX3lu5d7&redirect_uri=https%3A%2F%2Flocalhost%3A7220%2FLogin%2FLogin&response_type=code&scope=openid%20profile%20email&code_challenge=njrGTqgtZOImCX_Cx5EZw-Ae0MDzpoPnpb715vrEtfw&code_challenge_method=S256&response_mode=form_post&nonce=638295457035011848.NjFhZDc1YjYtNGZmNS00N2MzLTg4NGQtMDJkYWQ0NzZlNTJhZGNhYjBlMGQtYWZjMi00YjJiLTlhZGQtNDk2OGQxMDg0MmZm&state=CfDJ8JCfjCBGxQdClsNBcyaYvitJZ0MWxXZtiGPHMUz4E_H2uwG7720GMSEAegx9o6K3ODVoUfpFfyehDxksYJqJDUfUEACVHSq6YOQb2QHDjP6iD9kS96RDAvrkZ4z_YQBoRMXLM4Mpd7fxTzCYzNmNtncGXvICNyPrMdBgzOvuac_8bLlw9qCu3sTJj5Ma3sxoiM8DVRwEf-ld_DpKbmldZSIHMqKJAIH18Z2UPeXuNAAreBFzkWuRl3N_AUB63zuHypxgJK6YbAFL-0A3VJQ1CUbKHORjGXvwaHfEaQIqoISv9bPiaidADEYHdDWAL-gcHiIsxDAXCiU2xaYmMRbIRLQdsW-111nJFkWB_r5Hw12iIJahNp3XJnhAJb6GY0yzlg&x-client-SKU=ID_NET6_0&x-client-ver=6.32.0.0");
        return View();

    }
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(); 
        return RedirectToAction("Index", "Home");
    }
}