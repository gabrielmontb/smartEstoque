using CadastroOrdemRemessaTO;
using Dapper;
using Npgsql;
using SmartEstoque.Class;
using System.Collections.Generic;

namespace SmartEstoque.Business
{
    public class CadastroOrdemRemessaDAL
    {
        public bool inserirOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().inserirOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESORDRMS", objInserir.DESORDRMS);
            command.Parameters.AddWithValue("@CODMODPRD", objInserir.CODMODPRD);
            command.Parameters.AddWithValue("@CODFRNPRD", objInserir.CODFRNPRD);
            command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            command.Parameters.AddWithValue("@DATPRVENT",  objInserir.DATPRVENT);
            command.Parameters.AddWithValue("@CODNTAFSC", objInserir.CODNTAFSC);
            command.Parameters.AddWithValue("@VLRLOTRMS", Convert.ToDecimal(objInserir.VLRLOTRMS.Replace(".", ",")));
            command.Parameters.AddWithValue("@NUMLOTRMS", objInserir.NUMLOTRMS);
            command.Parameters.AddWithValue("@QDEPRD", objInserir.QDEPRD);

            command.Parameters.AddWithValue("@CODBARPRD", objInserir.CODBARPRD);
            command.Parameters.AddWithValue("@VLRUNTPRD", Convert.ToDecimal(objInserir.VLRUNTPRD.Replace(".", ",")));
            command.Parameters.AddWithValue("@DATVNCPRD", objInserir.DATVNCPRD);
            command.Parameters.AddWithValue("@DESPESPRD", objInserir.DESPESPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().alterarOrdemRemessa(objInserir);
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESORDRMS", objInserir.DESORDRMS);
            command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            command.Parameters.AddWithValue("@DATPRVENT", objInserir.DATPRVENT);
            command.Parameters.AddWithValue("@CODNTAFSC", objInserir.CODNTAFSC);
            command.Parameters.AddWithValue("@VLRLOTRMS", Convert.ToDecimal(objInserir.VLRLOTRMS.Replace(".", ",")));
            command.Parameters.AddWithValue("@NUMLOTRMS", objInserir.NUMLOTRMS);
            command.Parameters.AddWithValue("@QDEPRD", objInserir.QDEPRD);
            command.Parameters.AddWithValue("@CODBARPRD", objInserir.CODBARPRD == null ? 0 : objInserir.CODBARPRD);
            command.Parameters.AddWithValue("@DATVNCPRD", objInserir.DATVNCPRD == null ? "" : objInserir.DATVNCPRD);
            command.Parameters.AddWithValue("@VLRUNTPRD", Convert.ToDecimal(objInserir.VLRUNTPRD.Replace(".",",")));
            command.Parameters.AddWithValue("@DESPESPRD", objInserir.DESPESPRD);
            command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS);
            return (command.ExecuteNonQuery() == 1);
        }    
        public bool inserirProduto(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().inserirProduto();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESPRD", objInserir.DESMODPRD);
            command.Parameters.AddWithValue("@CODMODPRD", objInserir.CODMODPRD);
            command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS);
            command.Parameters.AddWithValue("@DATVNCPRD", objInserir.DATVNCPRD);
            command.Parameters.AddWithValue("@VLRUNTPRD", Convert.ToDecimal(objInserir.VLRUNTPRD.Replace(".", ",")));
            command.Parameters.AddWithValue("@DESPESPRD", objInserir.DESPESPRD);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().ativarOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().desativarOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS);
            return (command.ExecuteNonQuery() == 1);
        }
        public int obterTipoGrupo(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().obterTipoGrupo();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODMODPRD", objInserir.CODMODPRD);
            var retorno = command.ExecuteScalar();
            if (retorno != null)
                return Convert.ToInt32(retorno);
            else return 0;
        } 
        public List<obterOrdemRemessa> obterOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            var retorno = new List<obterOrdemRemessa>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().obterOrdemRemessa(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESORDRMS))
                command.Parameters.AddWithValue("@DESORDRMS", objInserir.DESORDRMS); 
            if (objInserir.CODORDRMS > 0)
                command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS); 
            if (objInserir.CODSTAORDRMS > 0)
                command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterOrdemRemessa {
                    CODORDRMS = dr.GetInt32(0)
                    , CODMODPRD = dr.GetInt32(1)
                    , DESMODPRD = dr.GetString(2)
                    , CODFRNPRD = dr.GetInt32(3)
                    , DESFRNPRD = dr.GetString(4)
                    , DATCAD = dr.GetString(5)
                    , DATPRVENT = dr.GetString(6)
                    , CODSTAORDRMS = dr.GetInt32(7)
                    , DESSTAORDRMS = dr.GetString(8)
                    , QDEPRD = dr.GetInt32(9)
                    , VLRLOTRMS = dr.GetDecimal(10)
                    , NUMLOTRMS = dr.GetInt32(11)
                    , CODBARPRD = dr.IsDBNull(12) ? "" : dr.GetString(12)
                    , DATFIM = dr.IsDBNull(13) ? "" : dr.GetString(13)
                    , DESORDRMS = dr.GetString(14)
                    , CODNOTFSC = dr.IsDBNull(15) ? "" : dr.GetString(15)
                    , INDPESQTD = dr.GetInt32(16)
                    , DATVNCPRD = dr.IsDBNull(17) ? "" : dr.GetString(17)
                    , VLRUNTPRD = dr.IsDBNull(18) ? 0 : dr.GetDecimal(18)
                    , DESPESPRD = dr.IsDBNull(19) ? 0 : dr.GetDecimal(19)
                    , DESPESPRDVND = dr.IsDBNull(20) ? 0 : dr.GetDecimal(20)                    
                    , QDEPRDVND = dr.IsDBNull(21) ? 0 : dr.GetInt32(21)
                });
            }
            return retorno;
        }
    }
}
