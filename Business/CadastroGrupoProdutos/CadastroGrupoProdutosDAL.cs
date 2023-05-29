using CadastroGrupoProdutosTO;
using Dapper;
using Npgsql;
using SmartEstoque.Class;
using System.Collections.Generic;

namespace SmartEstoque.Business
{
    public class CadastroGrupoProdutosDAL
    {
        public bool inserirGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroGrupoProdutosDALSQL().inserirGrupoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESGRPPRD", objInserir.DESGRPPRD);
            command.Parameters.AddWithValue("@INDPESQTD", objInserir.INDPESQTD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroGrupoProdutosDALSQL().alterarGrupoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESGRPPRD", objInserir.DESGRPPRD);
            command.Parameters.AddWithValue("@INDPESQTD", objInserir.INDPESQTD);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroGrupoProdutosDALSQL().ativarGrupoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroGrupoProdutosDALSQL().desativarGrupoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterGrupoProdutos> obterGrupoProdutos(CadastroGrupoProdutosModel.InserirCadastroGrupoProdutos objInserir)
        {
            var retorno = new List<obterGrupoProdutos>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroGrupoProdutosDALSQL().obterGrupoProdutos(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESGRPPRD))
                command.Parameters.AddWithValue("@DESGRPPRD", objInserir.DESGRPPRD); 
            if (objInserir.CODGRPPRD > 0)
                command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterGrupoProdutos { CODGRPPRD = dr.GetInt32(0), DESGRPPRD = dr.GetString(1), DATCAD = dr.GetString(2), DATDST = dr.IsDBNull(3) ? "" : dr.GetString(3), INDPESQTD = dr.GetInt32(4) });
            }
            return retorno;
        }
    }
}
