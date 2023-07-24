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
        public bool ConcluirVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().ConcluirVendas(objInserir);
        }  
        public List<obterVendas> obterVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().obterVendas(objInserir);
        }  
        public obterProdutosVendas obterProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().obterProdutos(objInserir);
        } 
        public List<obterRelacaoProdutos> obterRelacaoProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().obterRelacaoProdutos(objInserir);
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
        public bool validaVendaConcluida(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().validaVendaConcluida(objInserir);
        }   
        public bool inserirProdutoVenda(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            return new CadastroVendasBLL().inserirProdutoVenda(objInserir);
        } 
        public int obterCodigoVenda()
        {
            return new CadastroVendasBLL().obterCodigoVenda();
        }

    }
}