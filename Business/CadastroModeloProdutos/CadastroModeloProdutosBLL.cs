using CadastroModeloProdutosTO;
using Dapper;
using SmartEstoque.Class;

namespace SmartEstoque.Business
{
    public class CadastroModeloProdutosBLL
    {
        public bool inserirModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().inserirModeloProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public List<obterModeloProdutos> obterModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().obterModeloProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }   
        public bool alterarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().alterarModeloProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        public bool ativarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().ativarModeloProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }    
        public bool desativarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            try
            {
                return new CadastroModeloProdutosDAL().desativarModeloProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
