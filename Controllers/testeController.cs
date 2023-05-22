using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class TesteController : Controller
    {
        public bool testeconexao()
        {
            return new teste().testeconexao();
        }
    }
}