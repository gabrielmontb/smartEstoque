using CadastroTipoProdutosTO;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class CadastroTipoProdutos : Controller
    {
        public bool inserirTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            return new CadastroTipoProdutosBLL().inserirTipoProdutos(objInserir);
        }  
        public List<obterTipoProdutos> obterTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            return new CadastroTipoProdutosBLL().obterTipoProdutos(objInserir);
        } 
        public bool alterarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            return new CadastroTipoProdutosBLL().alterarTipoProdutos(objInserir);
        }
        public bool ativarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            return new CadastroTipoProdutosBLL().ativarTipoProdutos(objInserir);
        }
        public bool desativarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            return new CadastroTipoProdutosBLL().desativarTipoProdutos(objInserir);
        }

    }
}