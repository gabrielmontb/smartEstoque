using CadastroOrdemRemessaTO;
using Dapper;
using SmartEstoque.Class;

namespace SmartEstoque.Business
{
    public class CadastroOrdemRemessaBLL
    {
        public bool inserirOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().inserirOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public List<obterOrdemRemessa> obterOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().obterOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }   
        public bool alterarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().alterarOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        public bool ativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().ativarOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }    
        public bool desativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroOrdemRemessaDAL().desativarOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
