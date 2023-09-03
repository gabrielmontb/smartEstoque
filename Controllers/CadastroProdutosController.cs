using CadastroProdutosTO;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class CadastroProdutos : Controller
    {
        public bool inserirProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            return new CadastroProdutosBLL().inserirProdutos(objInserir);
        }  
        public List<obterProdutos> obterProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            return new CadastroProdutosBLL().obterProdutos(objInserir);
        } 
        public bool alterarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            return new CadastroProdutosBLL().alterarProdutos(objInserir);
        }
        public bool ativarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            return new CadastroProdutosBLL().ativarProdutos(objInserir);
        }
        public bool desativarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            return new CadastroProdutosBLL().desativarProdutos(objInserir);
        }

    }
}