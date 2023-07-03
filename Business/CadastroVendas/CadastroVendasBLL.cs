using CadastroProdutosTO;
using CadastroVendasTO;
using Dapper;
using SmartEstoque.Class;
using System.Transactions;

namespace SmartEstoque.Business
{
    public class CadastroVendasBLL
    {
        public bool inserirVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().inserirVendas(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public List<obterVendas> obterVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().obterVendas(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }    
        public obterProdutosVendas obterProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().obterProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        public List<obterRelacaoProdutos> obterRelacaoProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().obterRelacaoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }   
        public bool alterarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().alterarVendas(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        public bool ativarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().ativarVendas(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }    
        public bool desativarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().desativarVendas(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public bool inserirProdutoVenda(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            try
            {
                return new CadastroVendasDAL().inserirProdutoVenda(objInserir);
            }
            catch(Exception ex)
            {
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
            catch(Exception ex)
            {
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
