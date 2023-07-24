using Arquitetura.Classes;
using CadastroProdutosTO;
using CadastroVendasTO;
using Dapper;
using Newtonsoft.Json;
using SmartEstoque.Class;
using System.Reflection;
using System.Transactions;

namespace SmartEstoque.Business
{
    public class CadastroVendasBLL
    {
        public bool ConcluirVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope(TransactionScopeOption.Required, (new TimeSpan(0, 3, 0)))) // DE ATÉ 3 MINUTOS.
                {
                    var produtos = obterRelacaoProdutos(objInserir);
                    foreach (var item in produtos)
                    {
                        var remessa = new CadastroOrdemRemessaBLL().obterOrdemRemessa(new CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa() { CODORDRMS = item.CODORDRMS }).FirstOrDefault();
                        //remessa.qdeprdvnd = item.QUANTIDADE + remessa.qdeprdvnd;
                        //remessa.despesprdvnd = item.QUANTIDADE + remessa.despesprdvnd;
                        //if(!atualizaEstoque(remessa)){
                        //Scope.Dispose();
                        //return false;
                        //}
                    }

                    objInserir.VLRVND = produtos.Sum(X => X.VLRUNTPRD);
                    if (!new CadastroVendasDAL().ConcluirVendas(objInserir))
                    {
                        Scope.Dispose();
                        return false;
                    }
                    Scope.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterVendas> obterVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().obterVendas(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public obterProdutosVendas obterProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().obterProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public List<obterRelacaoProdutos> obterRelacaoProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().obterRelacaoProdutos(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool alterarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().alterarVendas(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool atualizaEstoque(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().atualizaEstoque(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool ativarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().ativarVendas(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool desativarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().desativarVendas(objInserir);
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir));
                throw ex;
            }
        }
        public bool inserirProdutoVenda(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope(TransactionScopeOption.Required, (new TimeSpan(0, 3, 0)))) // DE ATÉ 3 MINUTOS.
                {
                    var DAL = new CadastroVendasDAL();
                    if (!DAL.inserirProdutoVenda(objInserir))
                    {
                        Scope.Dispose();
                        return false;
                    }
                    if (!DAL.atualizaOrdemRemessa(objInserir))
                    {
                        Scope.Dispose();
                        return false;
                    }
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
        public bool validaVendaConcluida(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                var DAL = new CadastroVendasDAL();

                using (TransactionScope Scope = new TransactionScope(TransactionScopeOption.Required, (new TimeSpan(0, 3, 0)))) // DE ATÉ 3 MINUTOS.
                {
                    if (!DAL.validaVendaConcluida(objInserir))
                    {
                        if (!DAL.removeCadastroVenda(objInserir))
                        {
                            Scope.Dispose();
                            return false;
                        }
                    }
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
        public int obterCodigoVenda()
        {
            try
            {
                var DAL = new CadastroVendasDAL();
                var codigoVenda = DAL.obterCodigoVenda();
                DAL.cadastrarCodigoVenda(codigoVenda);
                return codigoVenda;
            }
            catch (Exception ex)
            {
                Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name);
                throw ex;
            }
        }
    }
}
