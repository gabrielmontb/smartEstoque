using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroProdutosDALSQL
    {
        public string inserirProdutos()
        {
            return @"INSERT INTO cadfrnprd (
                                                 codfrnprd
                                                ,desfrnprd
                                                ,datcad
                                                ,telctofrn
                                                ,telctofrnsec
                                                ,nomrspfrn
                                                ,desendfrn
                                                ,descidfrn
                                                ,desestafrn
                                            ) 
                    values (
                                (SELECT COALESCE(MAX(codfrnprd),0)+1 FROM cadfrnprd)
                                , UPPER(@DESFRNPRD)
                                ,NOW()
                                ,@TELCTOFRN
                                ,@TELCTOFRNSEC
                                ,@NOMRSPFRN
                                ,@DESENDFRN
                                ,@DESCIDFRN
                                ,@DESESTAFRN
                            )";
        }   
        public string obterProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT cad.codprd
                            , cad.desprd
                            , cad.codmodprd
                            , cad.codordrms
                            , cad.vlruntprd
                            , cad.despesprd
                            , TO_CHAR(cad.datvncprd, 'dd/MM/yyyy') datvncprd
                            , TO_CHAR(cad.datvndprd, 'dd/MM/yyyy') datvndprd
                            , TO_CHAR(cad.datcad, 'dd/MM/yyyy') datcad
                            , mod.desmodprd
                    FROM cadprd cad
                         INNER JOIN cadmodprd mod ON cad.codmodprd = mod.codmodprd
                    WHERE 1=1
                    
                ");
            if (objInserir.CODPRD > 0)
                strBld.AppendLine(" AND cad.codprd = @CODPRD ");
            if (!string.IsNullOrEmpty(objInserir.DESPRD))
                strBld.AppendLine(" AND UPPER(TRIM(cad.desprd)) LIKE '%' || UPPER(TRIM(@DESPRD))  || '%'");
            if(objInserir.STATUS == 1)
                strBld.AppendLine(" AND cad.datvndprd IS NULL ");
            else if (objInserir.STATUS == 2)
                strBld.AppendLine(" AND cad.datvndprd IS NOT NULL ");
            strBld.AppendLine("ORDER BY cad.codprd ");

            return strBld.ToString();
        } 
        public string alterarProdutos(CadastroProdutosModel.InserirCadastroProdutos objAlterar)
        {
            return @"UPDATE cadprd SET 
                            desprd = UPPER(@DESPRD)
                            , vlruntprd = @VLRUNTPRD
                            , despesprd = @DESPESPRD
                            #DATAVENCIMENTO
                            , datalt = NOW()
                             WHERE #FILTRO"
                        .Replace("#DATAVENCIMENTO" , string.IsNullOrEmpty(objAlterar.DATVNCPRD) ? "" : ",datvncprd = TO_DATE(@DATVNCPRD, 'DD/MM/YYYY')")
                        .Replace("#FILTRO", objAlterar.CODORDRMS > 0 ? "codordrms = @CODORDRMS" : "codprd = @CODPRD");
        }  
        public string ativarProdutos()
        {
            return @"UPDATE cadfrnprd SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codfrnprd = @CODFRNPRD";
        } 
        public string desativarProdutos()
        {
            return @"DELETE FROM cadprd WHERE codprd = @CODPRD";
        }
    }
}
