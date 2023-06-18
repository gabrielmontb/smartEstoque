using CadastroProdutosTO;
using Dapper;
using SmartEstoque.Class;

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
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public List<obterProdutos> obterProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().obterProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }   
        public bool alterarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().alterarProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        public bool ativarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().ativarProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }    
        public bool desativarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            try
            {
                return new CadastroProdutosDAL().desativarProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
