using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroTipoProdutosDALSQL
    {
        public string inserirTipoProdutos()
        {
            return @"INSERT INTO cadtipprd (codtipprd,destipprd,datcad,codgrpprd) values ((SELECT COALESCE(MAX(codtipprd),0)+1 FROM cadtipprd), UPPER(@DESTIPPRD),NOW(),@CODGRPPRD)";
        }   
        public string obterTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT TIP.codtipprd
                            , TIP.destipprd
                            , GRP.codgrpprd
                            , GRP.desgrpprd
                            , TO_CHAR(TIP.datcad, 'dd/MM/yyyy') datcad
                            , TO_CHAR(TIP.datdst, 'dd/MM/yyyy') datdst 
                    FROM cadtipprd TIP
                        INNER JOIN cadgrpprd GRP on TIP.codgrpprd = GRP.codgrpprd
                    WHERE 1=1
                    
                ");
            if (objInserir.CODTIPPRD > 0)
                strBld.AppendLine(" AND TIP.codtipprd = @CODTIPPRD ");
            if (objInserir.CODGRPPRD > 0)
                strBld.AppendLine(" AND TIP.codgrpprd = @CODGRPPRD ");
            if (!string.IsNullOrEmpty(objInserir.DESTIPPRD))
                strBld.AppendLine(" AND UPPER(TRIM(TIP.destipprd)) LIKE '%' || UPPER(TRIM(@DESTIPPRD))  || '%'");
            if(objInserir.STATUS == 1)
                strBld.AppendLine(" AND TIP.datdst IS NULL ");
            else if (objInserir.STATUS == 2)
                strBld.AppendLine(" AND TIP.datdst IS NOT NULL ");
            strBld.AppendLine("ORDER BY TIP.codtipprd ");

            return strBld.ToString();
        } 
        public string alterarTipoProdutos()
        {
            return @"UPDATE cadtipprd SET 
                            destipprd = UPPER(@DESTIPPRD)
                            , codgrpprd = @CODGRPPRD
                            , datalt = NOW()
                             WHERE codtipprd = @CODTIPPRD";
        }  
        public string ativarTipoProdutos()
        {
            return @"UPDATE cadtipprd SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codtipprd = @CODTIPPRD";
        } 
        public string desativarTipoProdutos()
        {
            return @"UPDATE cadtipprd SET 
                            datdst = NOW()
                             WHERE codtipprd = @CODTIPPRD";
        }
    }
}
