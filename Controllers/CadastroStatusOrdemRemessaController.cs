using CadastroStautsOrdemRemessaTO;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class CadastroStatusOrdemRemessa : Controller
    {
        public bool inserirStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            return new CadastroStautsOrdemRemessaBLL().inserirStatusOrdemRemessa(objInserir);
        }  
        public List<obterStatusOrdemRemessa> obterStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            return new CadastroStautsOrdemRemessaBLL().obterStatusOrdemRemessa(objInserir);
        } 
        public bool alterarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            return new CadastroStautsOrdemRemessaBLL().alterarStatusOrdemRemessa(objInserir);
        }
        public bool ativarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            return new CadastroStautsOrdemRemessaBLL().ativarStatusOrdemRemessa(objInserir);
        }
        public bool desativarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            return new CadastroStautsOrdemRemessaBLL().desativarStatusOrdemRemessa(objInserir);
        }

    }
}