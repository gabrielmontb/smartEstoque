using Arquitetura.Classes;
using CadastroProdutosTO;
using Dapper;
using Newtonsoft.Json;
using SmartEstoque.Class;
using System.Reflection;

namespace SmartEstoque.Business
{
    public class CadastroProdutosBLL
    {
        public bool inserirProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().inserirProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterProdutos> obterProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().obterProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool alterarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().alterarProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool ativarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().ativarProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool desativarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().desativarProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
    }
}
