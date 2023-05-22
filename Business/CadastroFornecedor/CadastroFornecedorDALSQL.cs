using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroFornecedorDALSQL
    {
        public string inserirFornecedor()
        {
            return @"INSERT INTO cadgrpprd (codgrpprd,desgrpprd,datcad) values ((SELECT COALESCE(MAX(codgrpprd),0)+1 FROM cadgrpprd), UPPER(@DESFRNPRD),NOW())";
        }   
        public string obterFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT codgrpprd
                            , desgrpprd
                            , TO_CHAR(datcad, 'dd/MM/yyyy') datcad
                            , TO_CHAR(datdst, 'dd/MM/yyyy') datdst 
                    FROM cadgrpprd 
                    WHERE 1=1
                    
                ");
            if (objInserir.CODFRNPRD > 0)
                strBld.AppendLine(" AND codgrpprd = @CODFRNPRD ");
            if (!string.IsNullOrEmpty(objInserir.DESFRNPRD))
                strBld.AppendLine(" AND UPPER(TRIM(desgrpprd)) LIKE '%' || UPPER(TRIM(@DESFRNPRD))  || '%'");
            if(objInserir.STATUS == 1)
                strBld.AppendLine(" AND datdst IS NULL ");
            else if (objInserir.STATUS == 2)
                strBld.AppendLine(" AND datdst IS NOT NULL ");
            strBld.AppendLine("ORDER BY codgrpprd ");

            return strBld.ToString();
        } 
        public string alterarFornecedor()
        {
            return @"UPDATE cadgrpprd SET 
                            desgrpprd = UPPER(@DESFRNPRD)
                            , datalt = NOW()
                             WHERE codgrpprd = @CODFRNPRD";
        }  
        public string ativarFornecedor()
        {
            return @"UPDATE cadgrpprd SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codgrpprd = @CODFRNPRD";
        } 
        public string desativarFornecedor()
        {
            return @"UPDATE cadgrpprd SET 
                            datdst = NOW()
                             WHERE codgrpprd = @CODFRNPRD";
        }
    }
}
