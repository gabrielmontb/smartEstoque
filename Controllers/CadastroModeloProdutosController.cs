using CadastroModeloProdutosTO;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class CadastroModeloProdutos : Controller
    {
        public bool inserirModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            return new CadastroModeloProdutosBLL().inserirModeloProdutos(objInserir);
        }  
        public List<obterModeloProdutos> obterModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            return new CadastroModeloProdutosBLL().obterModeloProdutos(objInserir);
        } 
        public bool alterarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            return new CadastroModeloProdutosBLL().alterarModeloProdutos(objInserir);
        }
        public bool ativarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            return new CadastroModeloProdutosBLL().ativarModeloProdutos(objInserir);
        }
        public bool desativarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            return new CadastroModeloProdutosBLL().desativarModeloProdutos(objInserir);
        }

    }
}