using CadastroModeloProdutosTO;
using Dapper;
using Npgsql;
using SmartEstoque.Class;
using System.Collections.Generic;

namespace SmartEstoque.Business
{
    public class CadastroModeloProdutosDAL
    {
        public bool inserirModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroModeloProdutosDALSQL().inserirModeloProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESMODPRD", objInserir.DESMODPRD);
            command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroModeloProdutosDALSQL().alterarModeloProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESMODPRD", objInserir.DESMODPRD);
            command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            command.Parameters.AddWithValue("@CODMODPRD", objInserir.CODMODPRD);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroModeloProdutosDALSQL().ativarModeloProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODMODPRD", objInserir.CODMODPRD);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroModeloProdutosDALSQL().desativarModeloProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODMODPRD", objInserir.CODMODPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterModeloProdutos> obterModeloProdutos(CadastroModeloProdutosModel.InserirCadastroModeloProdutos objInserir)
        {
            var retorno = new List<obterModeloProdutos>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroModeloProdutosDALSQL().obterModeloProdutos(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESMODPRD))
                command.Parameters.AddWithValue("@DESMODPRD", objInserir.DESMODPRD); 
            if (objInserir.CODMODPRD > 0)
                command.Parameters.AddWithValue("@CODMODPRD", objInserir.CODMODPRD); 
            if (objInserir.CODTIPPRD > 0)
                command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterModeloProdutos { 
                    CODMODPRD = dr.GetInt32(0)
                    , DESMODPRD = dr.GetString(1)
                    , CODTIPPRD = dr.GetInt32(2)
                    , DESTIPPRD = dr.GetString(3)
                    , DATCAD = dr.GetString(4)
                    , DATDST = dr.IsDBNull(5) ? "" : dr.GetString(5) 
                    , DESGRPPRD = dr.GetString(6)
                });
            }
            return retorno;
        }
    }
}
