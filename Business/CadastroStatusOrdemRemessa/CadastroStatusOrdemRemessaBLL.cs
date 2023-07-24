using Arquitetura.Classes;
using CadastroStautsOrdemRemessaTO;
using Dapper;
using Newtonsoft.Json;
using SmartEstoque.Class;
using System.Reflection;

namespace SmartEstoque.Business
{
    public class CadastroStautsOrdemRemessaBLL
    {
        public bool inserirStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().inserirStatusOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterStatusOrdemRemessa> obterStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().obterStatusOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool alterarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().alterarStatusOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool ativarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().ativarStatusOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool desativarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().desativarStatusOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
    }
}
