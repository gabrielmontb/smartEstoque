using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroStautsOrdemRemessaDALSQL
    {
        public string inserirStatusOrdemRemessa()
        {
            return @"INSERT INTO cadstaordrms (codstaordrms,desstaordrms,datcad) values ((SELECT COALESCE(MAX(codstaordrms),0)+1 FROM cadstaordrms), UPPER(@DESSTAORDRMS),NOW())";
        }   
        public string obterStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT codstaordrms
                            , desstaordrms
                            , TO_CHAR(datcad, 'dd/MM/yyyy') datcad
                            , TO_CHAR(datdst, 'dd/MM/yyyy') datdst 
                    FROM cadstaordrms 
                    WHERE 1=1
                    
                ");
            if (objInserir.CODSTAORDRMS > 0)
                strBld.AppendLine(" AND codstaordrms = @CODSTAORDRMS ");
            if (!string.IsNullOrEmpty(objInserir.DESSTAORDRMS))
                strBld.AppendLine(" AND UPPER(TRIM(desstaordrms)) LIKE '%' || UPPER(TRIM(@DESSTAORDRMS))  || '%'");
            if(objInserir.STATUS == 1)
                strBld.AppendLine(" AND datdst IS NULL ");
            else if (objInserir.STATUS == 2)
                strBld.AppendLine(" AND datdst IS NOT NULL ");
            strBld.AppendLine("ORDER BY codstaordrms ");

            return strBld.ToString();
        } 
        public string alterarStatusOrdemRemessa()
        {
            return @"UPDATE cadstaordrms SET 
                            desstaordrms = UPPER(@DESSTAORDRMS)
                            , datalt = NOW()
                             WHERE codstaordrms = @CODSTAORDRMS";
        }  
        public string ativarStatusOrdemRemessa()
        {
            return @"UPDATE cadstaordrms SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codstaordrms = @CODSTAORDRMS";
        } 
        public string desativarStatusOrdemRemessa()
        {
            return @"UPDATE cadstaordrms SET 
                            datdst = NOW()
                             WHERE codstaordrms = @CODSTAORDRMS";
        }
    }
}
