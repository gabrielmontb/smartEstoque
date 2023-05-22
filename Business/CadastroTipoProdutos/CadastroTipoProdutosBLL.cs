using CadastroTipoProdutosTO;
using Dapper;
using SmartEstoque.Class;

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
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public List<obterTipoProdutos> obterTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().obterTipoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }   
        public bool alterarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().alterarTipoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        public bool ativarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().ativarTipoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }    
        public bool desativarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            try
            {
                return new CadastroTipoProdutosDAL().desativarTipoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
