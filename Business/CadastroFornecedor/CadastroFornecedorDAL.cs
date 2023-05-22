using CadastroFornecedorTO;
using Dapper;
using Npgsql;
using SmartEstoque.Class;
using System.Collections.Generic;

namespace SmartEstoque.Business
{
    public class CadastroFornecedorDAL
    {
        public bool inserirFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().inserirFornecedor();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESGRPPRD", objInserir.DESGRPPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().alterarFornecedor();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESGRPPRD", objInserir.DESGRPPRD);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().ativarFornecedor();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().desativarFornecedor();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterFornecedor> obterFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            var retorno = new List<obterFornecedor>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().obterFornecedor(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESGRPPRD))
                command.Parameters.AddWithValue("@DESGRPPRD", objInserir.DESGRPPRD); 
            if (objInserir.CODGRPPRD > 0)
                command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterFornecedor { CODGRPPRD = dr.GetInt32(0), DESGRPPRD = dr.GetString(1), DATCAD = dr.GetString(2), DATDST = dr.IsDBNull(3) ? "" : dr.GetString(3) });
            }
            return retorno;
        }
    }
}
