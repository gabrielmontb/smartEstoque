using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroGrupoProdutosDALSQL
    {
        public string inserirGrupoProdutos()
        {
            return @"INSERT INTO cadgrpprd (codgrpprd,desgrpprd,datcad) values ((SELECT COALESCE(MAX(codgrpprd),0)+1 FROM cadgrpprd), UPPER(@DESGRPPRD),NOW())";
        }   
        public string obterGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT codgrpprd
                            , desgrpprd
                            , TO_CHAR(datcad, 'dd/MM/yyyy') datcad
                            , TO_CHAR(datdst, 'dd/MM/yyyy') datdst 
                    FROM cadgrpprd 
                    WHERE 1=1
                    
                ");
            if (objInserir.CODGRPPRD > 0)
                strBld.AppendLine(" AND codgrpprd = @CODGRPPRD ");
            if (!string.IsNullOrEmpty(objInserir.DESGRPPRD))
                strBld.AppendLine(" AND UPPER(TRIM(desgrpprd)) LIKE '%' || UPPER(TRIM(@DESGRPPRD))  || '%'");
            if(objInserir.STATUS == 1)
                strBld.AppendLine(" AND datdst IS NULL ");
            else if (objInserir.STATUS == 2)
                strBld.AppendLine(" AND datdst IS NOT NULL ");
            strBld.AppendLine("ORDER BY codgrpprd ");

            return strBld.ToString();
        } 
        public string alterarGrupoProdutos()
        {
            return @"UPDATE cadgrpprd SET 
                            desgrpprd = UPPER(@DESGRPPRD)
                            , datalt = NOW()
                             WHERE codgrpprd = @CODGRPPRD";
        }  
        public string ativarGrupoProdutos()
        {
            return @"UPDATE cadgrpprd SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codgrpprd = @CODGRPPRD";
        } 
        public string desativarGrupoProdutos()
        {
            return @"UPDATE cadgrpprd SET 
                            datdst = NOW()
                             WHERE codgrpprd = @CODGRPPRD";
        }
    }
}
