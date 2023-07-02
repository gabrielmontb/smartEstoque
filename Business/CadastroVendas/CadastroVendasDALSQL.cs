using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroVendasDALSQL
    {
        public string inserirVendas()
        {
            return @"INSERT INTO cadvndprd (codvndprd,datcad)
                            values ((SELECT COALESCE(MAX(codvndprd),0)+1 FROM cadvndprd),NOW())";
        }   
        public string obterVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
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
        public string obterProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT prd.codprd, prd.desprd, prd.vlruntprd, prd.codordrms, prd.codmodprd, qde.quantidade
	                    FROM cadprd prd
	                    INNER JOIN cadordrms ord ON prd.codordrms = ord.codordrms
	                    LEFT JOIN (
                        SELECT COUNT(codprd) quantidade, codordrms FROM cadprd WHERE datvndprd IS NULL GROUP BY codordrms
                    ) AS qde ON prd.codordrms = qde.codordrms
	                    WHERE prd.datvndprd IS NULL
                    
                ");
            if (objInserir.CODORDRMS > 0)
                strBld.AppendLine(" AND prd.codordrms = @CODORDRMS ");  
            if (objInserir.CODBARPRD > 0)
                strBld.AppendLine(" AND ord.codbarprd = @CODBARPRD ");
            if (!string.IsNullOrEmpty(objInserir.DESPRD))
                strBld.AppendLine(" AND UPPER(TRIM(prd.desprd)) LIKE '%' || UPPER(TRIM(@DESPRD))  || '%'");
            strBld.AppendLine("ORDER BY prd.codprd ");

            return strBld.ToString();
        } 
        public string alterarVendas()
        {
            return @"UPDATE cadtipprd SET 
                            destipprd = UPPER(@DESTIPPRD)
                            , codgrpprd = @CODGRPPRD
                            , datalt = NOW()
                             WHERE codtipprd = @CODTIPPRD";
        }  
        public string ativarVendas()
        {
            return @"UPDATE cadtipprd SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codtipprd = @CODTIPPRD";
        } 
        public string desativarVendas()
        {
            return @"UPDATE cadtipprd SET 
                            datdst = NOW()
                             WHERE codtipprd = @CODTIPPRD";
        }
    }
}
