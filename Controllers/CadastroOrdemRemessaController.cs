using CadastroOrdemRemessaTO;
using Microsoft.AspNetCore.Mvc;
using SmartEstoque.Business;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Web.Http;

namespace SmartEstoque.Controllers
{
    public class CadastroOrdemRemessa : Controller
    {
        public bool inserirOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            return new CadastroOrdemRemessaBLL().inserirOrdemRemessa(objInserir);
        }  
        public List<obterOrdemRemessa> obterOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            return new CadastroOrdemRemessaBLL().obterOrdemRemessa(objInserir);
        } 
        public bool alterarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            return new CadastroOrdemRemessaBLL().alterarOrdemRemessa(objInserir);
        }
        public bool ativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            return new CadastroOrdemRemessaBLL().ativarOrdemRemessa(objInserir);
        }
        public bool desativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            return new CadastroOrdemRemessaBLL().desativarOrdemRemessa(objInserir);
        }  
        public int obterTipoGrupo(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            return new CadastroOrdemRemessaBLL().obterTipoGrupo(objInserir);
        }

    }
}