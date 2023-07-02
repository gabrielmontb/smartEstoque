using CadastroProdutosTO;
using CadastroVendasTO;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class CadastroVendas : Controller
    {
        public bool inserirVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().inserirVendas(objInserir);
        }  
        public List<obterVendas> obterVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().obterVendas(objInserir);
        }  
        public obterProdutosVendas obterProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().obterProdutos(objInserir);
        } 
        public bool alterarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().alterarVendas(objInserir);
        }
        public bool ativarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().ativarVendas(objInserir);
        }
        public bool desativarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().desativarVendas(objInserir);
        }

    }
}