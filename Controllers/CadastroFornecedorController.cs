using CadastroFornecedorTO;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class CadastroFornecedor : Controller
    {
        public bool inserirFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            return new CadastroFornecedorBLL().inserirFornecedor(objInserir);
        }  
        public List<obterFornecedor> obterFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            return new CadastroFornecedorBLL().obterFornecedor(objInserir);
        } 
        public bool alterarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            return new CadastroFornecedorBLL().alterarFornecedor(objInserir);
        }
        public bool ativarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            return new CadastroFornecedorBLL().ativarFornecedor(objInserir);
        }
        public bool desativarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            return new CadastroFornecedorBLL().desativarFornecedor(objInserir);
        }

    }
}