using Arquitetura.Classes;
using CadastroModeloProdutosTO;
using Dapper;
using Newtonsoft.Json;
using SmartEstoque.Class;
using System.Reflection;

namespace SmartEstoque.Business
{
    public class CadastroModeloProdutosBLL
    {
        public bool inserirModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().inserirModeloProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterModeloProdutos> obterModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().obterModeloProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool alterarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().alterarModeloProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool ativarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().ativarModeloProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool desativarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().desativarModeloProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
    }
}
