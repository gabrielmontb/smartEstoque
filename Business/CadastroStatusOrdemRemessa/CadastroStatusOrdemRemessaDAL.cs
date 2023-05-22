using CadastroStautsOrdemRemessaTO;
using Dapper;
using Npgsql;
using SmartEstoque.Class;
using System.Collections.Generic;

namespace SmartEstoque.Business
{
    public class CadastroStautsOrdemRemessaDAL
    {
        public bool inserirStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroStautsOrdemRemessaDALSQL().inserirStatusOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESSTAORDRMS", objInserir.DESSTAORDRMS);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroStautsOrdemRemessaDALSQL().alterarStatusOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESSTAORDRMS", objInserir.DESSTAORDRMS);
            command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroStautsOrdemRemessaDALSQL().ativarStatusOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroStautsOrdemRemessaDALSQL().desativarStatusOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterStatusOrdemRemessa> obterStatusOrdemRemessa(CadastroStatusOrdemSemessaModel.InserirCadastroStatusOrdemRemessa objInserir)
        {
            var retorno = new List<obterStatusOrdemRemessa>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroStautsOrdemRemessaDALSQL().obterStatusOrdemRemessa(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESSTAORDRMS))
                command.Parameters.AddWithValue("@DESSTAORDRMS", objInserir.DESSTAORDRMS); 
            if (objInserir.CODSTAORDRMS > 0)
                command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterStatusOrdemRemessa { CODSTAORDRMS = dr.GetInt32(0), DESSTAORDRMS = dr.GetString(1), DATCAD = dr.GetString(2), DATDST = dr.IsDBNull(3) ? "" : dr.GetString(3) });
            }
            return retorno;
        }
    }
}
