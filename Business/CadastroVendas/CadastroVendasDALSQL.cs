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
                    SELECT ord.vlruntprd
					, ord.codordrms
					, ord.codmodprd
					, CASE WHEN GRP.indpesqtd = 1
					  	THEN (ord.despesprd - COALESCE(ord.despesprdvnd,0))
						ELSE (ord.qdeprd- COALESCE(ord.qdeprdvnd,0))
					END quantidade
					, CMOD.desmodprd
					, GRP.indpesqtd
	                FROM cadordrms ord
						INNER JOIN cadmodprd CMOD ON ord.codmodprd = CMOD.codmodprd
                        INNER JOIN cadtipprd TIP ON CMOD.codtipprd = TIP.codtipprd
	                    INNER JOIN cadgrpprd GRP ON TIP.CODGRPPRD = GRP.CODGRPPRD
	                WHERE (((ord.qdeprd- COALESCE(ord.qdeprdvnd,0)) > 0) or (ord.despesprd - COALESCE(ord.despesprdvnd,0)) > 0)          
                ");
            if (objInserir.CODORDRMS > 0)
                strBld.AppendLine(" AND ord.codordrms = @CODORDRMS ");  
            if (objInserir.CODBARPRD > 0)
                strBld.AppendLine(" AND ord.codbarprd = @CODBARPRD ");
            if (!string.IsNullOrEmpty(objInserir.DESPRD))
                strBld.AppendLine(" AND UPPER(TRIM(cmod.desmodprd)) LIKE '%' || UPPER(TRIM(@DESPRD))  || '%'");
            strBld.AppendLine("ORDER BY ord.codordrms ");

            return strBld.ToString();
        } 
        public string obterRelacaoProdutos()
        {
            return @"SELECT RLC.codordrms, 
						CMOD.desmodprd, 
						CASE WHEN GRP.indpesqtd = 1
						THEN RLC.despesprdvnd 
						ELSE RLC.qdeprdvnd END quantidade, 
						RMS.vlruntprd
						FROM rlcvndprd RLC 
						INNER JOIN cadordrms RMS ON RLC.codordrms = RMS.codordrms
						INNER JOIN cadmodprd CMOD ON RMS.codmodprd = CMOD.codmodprd
						INNER JOIN cadtipprd TIP ON CMOD.codtipprd = TIP.codtipprd
						INNER JOIN cadgrpprd GRP ON TIP.codgrpprd = GRP.codgrpprd
					    WHERE RLC.codvndprd = @CODVNDPRD";
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
        public string inserirProdutoVenda()
        {
            return @"INSERT INTO rlcvndprd (codvndprd,codordrms,qdeprdvnd,despesprdvnd,datcad)
						VALUES (@CODVNDPRD,@CODORDRMS,@QDEPRDVND,@DESPESPRDVND,NOW())";
        }  
        public string removeCadastroVenda()
        {
            return @"DELETE FROM cadvndprd WHERE codvndprd = @CODVNDPRD";
        }  
        public string validaVendaConcluida()
        {
            return @"SELECT codvndprd FROM rlcvndprd WHERE codvndprd = @CODVNDPRD";
        } 
        public string obterCodigoVenda()
        {
            return @"SELECT COALESCE(MAX(codvndprd),0)+1 FROM cadvndprd";
        }
        public string cadastrarCodigoVenda()
        {
            return @"INSERT INTO cadvndprd (codvndprd,datcad)
                            values (@CODVNDPRD,NOW())";
        }
    }
}
