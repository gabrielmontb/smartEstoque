using Arquitetura.Classes;
using CadastroFornecedorTO;
using Dapper;
using Newtonsoft.Json;
using SmartEstoque.Class;
using System.Reflection;

namespace SmartEstoque.Business
{
    public class CadastroFornecedorBLL
    {
        public bool inserirFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            try
            {
                return new CadastroFornecedorDAL().inserirFornecedor(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterFornecedor> obterFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            try
            {
                return new CadastroFornecedorDAL().obterFornecedor(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool alterarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            try
            {
                return new CadastroFornecedorDAL().alterarFornecedor(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool ativarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            try
            {
                return new CadastroFornecedorDAL().ativarFornecedor(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool desativarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            try
            {
                return new CadastroFornecedorDAL().desativarFornecedor(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
    }
}
