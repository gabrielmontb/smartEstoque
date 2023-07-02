using CadastroProdutosTO;
using CadastroVendasTO;
using Dapper;
using SmartEstoque.Class;

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
    }
}
