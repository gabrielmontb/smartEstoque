using CadastroGrupoProdutosTO;
using Dapper;
using SmartEstoque.Class;

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
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public List<obterGrupoProdutos> obterGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().obterGrupoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }   
        public bool alterarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().alterarGrupoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        public bool ativarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().ativarGrupoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }    
        public bool desativarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            try
            {
                return new CadastroGrupoProdutosDAL().desativarGrupoProdutos(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
