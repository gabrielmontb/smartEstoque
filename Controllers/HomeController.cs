using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Models;
using System.Diagnostics;

namespace SmartEstoque.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CadastroStatusOrdemRemessa()
        {
            return View("/Views/Paginas/CadastroStatusOrdemRemessa/Index.cshtml");
        } 
        public IActionResult CadastroOrdemRemessa()
        {
            return View("/Views/Paginas/CadastroOrdemRemessa/Index.cshtml");
        }  
        public IActionResult CadastroModeloProdutos()
        {
            return View("/Views/Paginas/CadastroModeloProdutos/Index.cshtml");
        }  
        public IActionResult CadastroGrupoProdutos()
        {
            return View("/Views/Paginas/CadastroGrupoProdutos/Index.cshtml");
        }        
        public IActionResult CadastroTipoProdutos()
        {
            return View("/Views/Paginas/CadastroTipoProdutos/Index.cshtml");
        }  
        public IActionResult CadastroFornecedor()
        {
            return View("/Views/Paginas/CadastroFornecedor/Index.cshtml");
        }
        public IActionResult CadastroProdutos()
        {
            return View("/Views/Paginas/CadastroProdutos/Index.cshtml");
        } 
        public IActionResult CadastroVendas()
        {
            return View("/Views/Paginas/CadastroVendas/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}