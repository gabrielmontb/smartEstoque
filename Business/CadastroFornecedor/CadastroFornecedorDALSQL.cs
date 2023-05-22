using Dapper;
using SmartEstoque.Class;
using System.Text;

namespace SmartEstoque.Business
{
    public class CadastroFornecedorDALSQL
    {
        public string inserirFornecedor()
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
        public string obterFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            StringBuilder strBld = new StringBuilder(@"
                     SELECT codfrnprd
                            , desfrnprd
                            , TO_CHAR(datcad, 'dd/MM/yyyy') datcad
                            , TO_CHAR(datdst, 'dd/MM/yyyy') datdst 
                            , telctofrn
                            , telctofrnsec
                            , nomrspfrn
                            , desendfrn
                            , descidfrn
                            , desestafrn
                    FROM cadfrnprd 
                    WHERE 1=1
                    
                ");
            if (objInserir.CODFRNPRD > 0)
                strBld.AppendLine(" AND codfrnprd = @CODFRNPRD ");
            if (!string.IsNullOrEmpty(objInserir.DESFRNPRD))
                strBld.AppendLine(" AND UPPER(TRIM(desfrnprd)) LIKE '%' || UPPER(TRIM(@DESFRNPRD))  || '%'");
            if(objInserir.STATUS == 1)
                strBld.AppendLine(" AND datdst IS NULL ");
            else if (objInserir.STATUS == 2)
                strBld.AppendLine(" AND datdst IS NOT NULL ");
            strBld.AppendLine("ORDER BY codfrnprd ");

            return strBld.ToString();
        } 
        public string alterarFornecedor()
        {
            return @"UPDATE cadfrnprd SET 
                            desfrnprd = UPPER(@DESFRNPRD)
                            , telctofrn = @TELCTOFRN
                            , telctofrnsec = @TELCTOFRNSEC
                            , nomrspfrn = @NOMRSPFRN
                            , desendfrn = @DESENDFRN
                            , descidfrn = @DESCIDFRN
                            , desestafrn = @DESESTAFRN
                            , datalt = NOW()
                             WHERE codfrnprd = @CODFRNPRD";
        }  
        public string ativarFornecedor()
        {
            return @"UPDATE cadfrnprd SET 
                            datdst = null
                            , datalt = NOW()
                             WHERE codfrnprd = @CODFRNPRD";
        } 
        public string desativarFornecedor()
        {
            return @"UPDATE cadfrnprd SET 
                            datdst = NOW()
                             WHERE codfrnprd = @CODFRNPRD";
        }
    }
}
