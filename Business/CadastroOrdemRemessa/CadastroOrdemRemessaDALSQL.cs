using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroOrdemRemessaDALSQL
    {
        public string inserirOrdemRemessa()
        {
            return @"INSERT INTO cadordrms (
                                                 codordrms
                                                , desordrms
                                                , codmodprd
                                                , codfrnprd
                                                , codstaordrms
                                                , datprvent
                                                , codntafsc
                                                , vlrlotrms
                                                , numlotrms
                                                , qdeprd
                                                , datcad
                                            ) 
                            values (
                                          (SELECT COALESCE(MAX(codordrms),0)+1 FROM cadordrms)
                                        , UPPER(@DESORDRMS)
                                        , @CODMODPRD
                                        , @CODFRNPRD
                                        , @CODSTAORDRMS
                                        , TO_DATE(@DATPRVENT, 'DD/MM/YYYY')
                                        , @CODNTAFSC
                                        , @VLRLOTRMS
                                        , @NUMLOTRMS
                                        , @QDEPRD
                                        , NOW()
                                    )";
        }   
        public string obterOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT  ORD.codordrms
                            , ORD.codmodprd
                            , MOD.desmodprd
                            , ORD.codfrnprd
                            , FRN.desfrnprd
                            , TO_CHAR(ORD.datcad, 'dd/MM/yyyy') datcad
                            , TO_CHAR(ORD.datprvent, 'dd/MM/yyyy') datprvent 
                            , ORD.codstaordrms
                            , STA.desstaordrms
                            , ORD.qdeprd
                            , ORD.vlrlotrms
                            , ORD.numlotrms
                            , ORD.codbarprd
                            , TO_CHAR(ORD.datfim, 'dd/MM/yyyy') datfim 
                            , ORD.desordrms
                            , ORD.codntafsc
                            , GRP.indpesqtd
                            , TO_CHAR(ORD.datvncprd, 'dd/MM/yyyy') datvncprd 
                            , ORD.vlruntprd
                            , ORD.despesprd
                    FROM cadordrms ORD
                        INNER JOIN cadfrnprd FRN ON ORD.codfrnprd = FRN.codfrnprd
                        INNER JOIN cadstaordrms STA ON ORD.codstaordrms = STA.codstaordrms
                        INNER JOIN cadmodprd MOD ON ORD.codmodprd = MOD.codmodprd
                        INNER JOIN cadtipprd TIP ON MOD.codtipprd = TIP.codtipprd
                        INNER JOIN cadgrpprd GRP ON TIP.codgrpprd = GRP.codgrpprd
                    WHERE 1=1
                    
                ");
            if (objInserir.CODSTAORDRMS > 0)
                strBld.AppendLine(" AND ORD.codordrms = @CODORDRMS ");
            if (!string.IsNullOrEmpty(objInserir.DESORDRMS))
                strBld.AppendLine(" AND UPPER(TRIM(ORD.desordrms)) LIKE '%' || UPPER(TRIM(@DESORDRMS))  || '%'");
            if(objInserir.STATUS == 1)
                strBld.AppendLine(" AND ORD.datdst IS NULL ");
            else if (objInserir.STATUS == 2)
                strBld.AppendLine(" AND ORD.datdst IS NOT NULL ");
            strBld.AppendLine("ORDER BY ORD.codordrms ");

            return strBld.ToString();
        } 
        public string alterarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            return @"UPDATE cadordrms SET 
                              desordrms = UPPER(@DESORDRMS)
                            , codstaordrms = @CODSTAORDRMS
                            , datprvent = TO_DATE(@DATPRVENT, 'DD/MM/YYYY')
                            , codntafsc = @CODNTAFSC
                            , vlrlotrms = @VLRLOTRMS
                            , numlotrms = @NUMLOTRMS
                            , qdeprd = @QDEPRD
                            , codbarprd = @CODBARPRD
                            , datvncprd = TO_DATE(@DATVNCPRD, 'DD/MM/YYYY')
                            , vlruntprd = @VLRUNTPRD
                            , despesprd = @DESPESPRD
                            , datalt = NOW()
                            #FIM
                             WHERE codordrms = @CODORDRMS".Replace("#FIM", objInserir.CODSTAORDRMS == 2 ? ", datfim = NOW()" : "");
        }    
        public string inserirProduto()
        {
            return @"INSERT INTO cadprd (
                                                 codprd
                                                , desprd
                                                , codmodprd
                                                , codordrms
                                                , datvncprd
                                                , vlruntprd
                                                , despesprd
                                                , datcad
                                            ) 
                            values (
                                          (SELECT COALESCE(MAX(codprd),0)+1 FROM cadprd)
                                        , UPPER(@DESPRD)
                                        , @CODMODPRD
                                        , @CODORDRMS
                                        , TO_DATE(@DATVNCPRD, 'DD/MM/YYYY')
                                        , @VLRUNTPRD
                                        , @DESPESPRD
                                        , NOW()
                                    )";
        }  
        public string ativarOrdemRemessa()
        {
            return @"UPDATE cadordrms SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codordrms = @CODORDRMS";
        } 
        public string desativarOrdemRemessa()
        {
            return @"UPDATE cadordrms SET 
                            datdst = NOW()
                             WHERE codordrms = @CODORDRMS";
        }
    }
}
