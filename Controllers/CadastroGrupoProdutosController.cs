using CadastroGrupoProdutosTO;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class CadastroGrupoProdutos : Controller
    {
        public bool inserirGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            return new CadastroGrupoProdutosBLL().inserirGrupoProdutos(objInserir);
        }  
        public List<obterGrupoProdutos> obterGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            return new CadastroGrupoProdutosBLL().obterGrupoProdutos(objInserir);
        } 
        public bool alterarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            return new CadastroGrupoProdutosBLL().alterarGrupoProdutos(objInserir);
        }
        public bool ativarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            return new CadastroGrupoProdutosBLL().ativarGrupoProdutos(objInserir);
        }
        public bool desativarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            return new CadastroGrupoProdutosBLL().desativarGrupoProdutos(objInserir);
        }

    }
}