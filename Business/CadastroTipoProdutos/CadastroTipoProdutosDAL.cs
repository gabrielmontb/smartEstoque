using CadastroTipoProdutosTO;
using Dapper;
using Npgsql;
using SmartEstoque.Class;
using System.Collections.Generic;

namespace SmartEstoque.Business
{
    public class CadastroTipoProdutosDAL
    {
        public bool inserirTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroTipoProdutosDALSQL().inserirTipoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESTIPPRD", objInserir.DESTIPPRD);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroTipoProdutosDALSQL().alterarTipoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESTIPPRD", objInserir.DESTIPPRD);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroTipoProdutosDALSQL().ativarTipoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroTipoProdutosDALSQL().desativarTipoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterTipoProdutos> obterTipoProdutos(CadastroTipoProdutosModel.InserirCadastroTipoProdutos objInserir)
        {
            var retorno = new List<obterTipoProdutos>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroTipoProdutosDALSQL().obterTipoProdutos(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESTIPPRD))
                command.Parameters.AddWithValue("@DESTIPPRD", objInserir.DESTIPPRD); 
            if (objInserir.CODTIPPRD > 0)
                command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);     
            if (objInserir.CODGRPPRD > 0)
                command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterTipoProdutos { 
                    CODTIPPRD = dr.GetInt32(0), 
                    DESTIPPRD = dr.GetString(1), 
                    CODGRPPRD = dr.GetInt32(2), 
                    DESGRPPRD = dr.GetString(3), 
                    DATCAD = dr.GetString(4), 
                    DATDST = dr.IsDBNull(5) ? "" : dr.GetString(5) 
                });
            }
            return retorno;
        }
    }
}
