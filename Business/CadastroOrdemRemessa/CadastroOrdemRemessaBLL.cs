using Arquitetura.Classes;
using CadastroOrdemRemessaTO;
using Dapper;
using Newtonsoft.Json;
using SmartEstoque.Class;
using System.Reflection;
using System.Transactions;

namespace SmartEstoque.Business
{
    public class CadastroOrdemRemessaBLL
    {
        public bool inserirOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().inserirOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterOrdemRemessa> obterOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().obterOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool alterarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope(TransactionScopeOption.Required, (new TimeSpan(0, 3, 0)))) // DE ATÉ 3 MINUTOS.
                {
                    var DAL = new CadastroOrdemRemessaDAL();
                    var DALPRD = new CadastroProdutosDAL();
                    if (!DAL.alterarOrdemRemessa(objInserir))
                    {
                        Scope.Dispose();
                        return false;
                    }
                    //if (objInserir.CODSTAORDRMS == 2)
                    //{
                    //    if(objInserir.INDPESQTD == 1)//por peso
                    //    {
                    //        if (!DAL.inserirProduto(objInserir))
                    //        {
                    //            Scope.Dispose();
                    //            return false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        objInserir.DESPESPRD = 0;
                    //        for(int i=0; i< objInserir.QDEPRD; i++)
                    //        {
                    //            if (!DAL.inserirProduto(objInserir))
                    //            {
                    //                Scope.Dispose();
                    //                return false;
                    //            }
                    //        }
                    //    }
                    //}
                    Scope.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool ativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().ativarOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool desativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().desativarOrdemRemessa(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public int obterTipoGrupo(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().obterTipoGrupo(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
    }
}
