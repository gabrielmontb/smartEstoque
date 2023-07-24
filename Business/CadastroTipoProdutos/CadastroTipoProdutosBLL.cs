using Arquitetura.Classes;
using CadastroTipoProdutosTO;
using Dapper;
using Newtonsoft.Json;
using SmartEstoque.Class;
using System.Reflection;

namespace SmartEstoque.Business
{
    public class CadastroTipoProdutosBLL
    {
        public bool inserirTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().inserirTipoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterTipoProdutos> obterTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().obterTipoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool alterarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().alterarTipoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool ativarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().ativarTipoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool desativarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().desativarTipoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
    }
}
