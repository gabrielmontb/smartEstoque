using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroModeloProdutosDALSQL
    {
        public string inserirModeloProdutos()
        {
            return @"INSERT INTO cadmodprd (codmodprd,desmodprd,codtipprd,datcad) values ((SELECT COALESCE(MAX(codmodprd),0)+1 FROM cadmodprd), UPPER(@DESMODPRD), @CODTIPPRD, NOW())";
        }   
        public string obterModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT MOD.codmodprd
                            , UPPER(TRIM(MOD.desmodprd)) desmodprd
                            , TIP.codtipprd
                            , TIP.destipprd
                            , TO_CHAR(MOD.datcad, 'dd/MM/yyyy') datcad
                            , TO_CHAR(MOD.datdst, 'dd/MM/yyyy') datdst 
                    FROM cadmodprd MOD
                    INNER JOIN cadtipprd TIP ON MOD.codtipprd = TIP.codtipprd
                    WHERE 1=1
                    
                ");
            if (!string.IsNullOrEmpty(objInserir.DESMODPRD))
                strBld.AppendLine(" AND UPPER(TRIM(MOD.desmodprd)) LIKE '%' || UPPER(TRIM(@DESMODPRD))  || '%'");
            if (objInserir.CODMODPRD > 0)
                strBld.AppendLine(" AND MOD.codmodprd = @CODMODPRD "); 
            if (objInserir.CODTIPPRD > 0)
                strBld.AppendLine(" AND TIP.codtipprd = @CODTIPPRD ");
            if(objInserir.STATUS == 1)
                strBld.AppendLine(" AND MOD.datdst IS NULL ");
            else if (objInserir.STATUS == 2)
                strBld.AppendLine(" AND MOD.datdst IS NOT NULL ");
            strBld.AppendLine("ORDER BY MOD.codmodprd ");

            return strBld.ToString();
        } 
        public string alterarModeloProdutos()
        {
            return @"UPDATE cadmodprd SET 
                            desmodprd = UPPER(@DESMODPRD)
                            , codtipprd = @CODTIPPRD
                            , datalt = NOW()
                             WHERE codmodprd = @CODMODPRD";
        }  
        public string ativarModeloProdutos()
        {
            return @"UPDATE cadmodprd SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codmodprd = @CODMODPRD";
        } 
        public string desativarModeloProdutos()
        {
            return @"UPDATE cadmodprd SET 
                            datdst = NOW()
                             WHERE codmodprd = @CODMODPRD";
        }
    }
}
