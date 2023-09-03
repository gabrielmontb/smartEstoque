using Microsoft.AspNetCore.Mvc;

namespace SmartEstoque.Models
{
    internal class AppSettings
    {        
        public string OktaDomain { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationServerId { get; set; }
        public string CallbackPath { get; set; }
        public string URLOktaAPI { get; set; }
        
    }
    internal class profile
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}