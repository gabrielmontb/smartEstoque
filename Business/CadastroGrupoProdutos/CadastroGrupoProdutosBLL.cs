using Arquitetura.Classes;
using CadastroGrupoProdutosTO;
using Dapper;
using Newtonsoft.Json;
using SmartEstoque.Class;
using System.Reflection;

namespace SmartEstoque.Business
{
    public class CadastroGrupoProdutosBLL
    {
        public bool inserirGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().inserirGrupoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterGrupoProdutos> obterGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().obterGrupoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool alterarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().alterarGrupoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool ativarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().ativarGrupoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool desativarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().desativarGrupoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
    }
}
