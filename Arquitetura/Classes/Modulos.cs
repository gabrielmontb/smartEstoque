using Arquitetura.Classes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SmartEstoque.Models;
using System.Security.Claims;

public class Modulos : Controller
{
    public async Task<int> GrupoAcesso()
    {
        try{
            string user = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null)
                return 0;
            var URL = Util.AppSettings.OktaDomain;
            var MET = Util.AppSettings.URLOktaAPI;
            MET = MET.Replace("#USUARIO", user);
            var options = new RestClientOptions(URL)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(MET, Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "SSWS 00WTxSbmpz-0DDnGuYxhppP6LaukEeKw_XN_vtO1aV");
            RestResponse response = await client.ExecuteAsync(request);
            if (response == null || response?.IsSuccessStatusCode == false || response?.Content == null)
                return 0;
            List<string> groupNames = new List<string>();
            JArray jsonArray = JArray.Parse(response.Content);
            foreach (JObject jsonObject in jsonArray)
            {
                string groupName = (string)jsonObject["profile"]["name"];
                groupNames.Add(groupName);
            }
            if (groupNames?.Count == 0)
                return 0;
            if (groupNames.Any(X => X == "Administrador"))
                return 1;
            else if (groupNames.Any(X => X == "Consultor"))
                return 2;
            else return 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

