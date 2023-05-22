using CadastroStautsOrdemRemessaTO;
using Dapper;
using SmartEstoque.Class;

namespace SmartEstoque.Business
{
    public class CadastroStautsOrdemRemessaBLL
    {
        public bool inserirStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().inserirStatusOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public List<obterStatusOrdemRemessa> obterStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().obterStatusOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }   
        public bool alterarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().alterarStatusOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        public bool ativarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().ativarStatusOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }    
        public bool desativarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            try
            {
                return new CadastroStautsOrdemRemessaDAL().desativarStatusOrdemRemessa(objInserir);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
