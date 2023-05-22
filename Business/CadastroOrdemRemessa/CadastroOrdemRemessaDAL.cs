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
            command.Parameters.AddWithValue("@DESSTAORDRMS", objInserir.DESSTAORDRMS);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().alterarOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESSTAORDRMS", objInserir.DESSTAORDRMS);
            command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().ativarOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().desativarOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterOrdemRemessa> obterOrdemRemessa(CadastroOrdemRemessaModel.InserirCadastroOrdemRemessa objInserir)
        {
            var retorno = new List<obterOrdemRemessa>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroOrdemRemessaDALSQL().obterOrdemRemessa(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESSTAORDRMS))
                command.Parameters.AddWithValue("@DESSTAORDRMS", objInserir.DESSTAORDRMS); 
            if (objInserir.CODSTAORDRMS > 0)
                command.Parameters.AddWithValue("@CODSTAORDRMS", objInserir.CODSTAORDRMS);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterOrdemRemessa { CODSTAORDRMS = dr.GetInt32(0), DESSTAORDRMS = dr.GetString(1), DATCAD = dr.GetString(2), DATDST = dr.IsDBNull(3) ? "" : dr.GetString(3) });
            }
            return retorno;
        }
    }
}
