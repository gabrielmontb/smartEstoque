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
            command.Parameters.AddWithValue("@DESFRNPRD", objInserir.DESFRNPRD);
            command.Parameters.AddWithValue("@TELCTOFRN", objInserir.TELCTOFRN.Replace("/[^0-9]/g", ""));
            command.Parameters.AddWithValue("@TELCTOFRNSEC", objInserir.TELCTOFRNSEC.Replace("/[^0-9]/g", ""));
            command.Parameters.AddWithValue("@NOMRSPFRN", objInserir.NOMRSPFRN);
            command.Parameters.AddWithValue("@DESENDFRN", objInserir.DESENDFRN);
            command.Parameters.AddWithValue("@DESCIDFRN", objInserir.DESCIDFRN);
            command.Parameters.AddWithValue("@DESESTAFRN", objInserir.DESESTAFRN);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().alterarFornecedor();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESFRNPRD", objInserir.DESFRNPRD);
            command.Parameters.AddWithValue("@TELCTOFRN", objInserir.TELCTOFRN.Replace("/[^0-9]/g", ""));
            command.Parameters.AddWithValue("@TELCTOFRNSEC", objInserir.TELCTOFRNSEC.Replace("/[^0-9]/g", ""));
            command.Parameters.AddWithValue("@NOMRSPFRN", objInserir.NOMRSPFRN);
            command.Parameters.AddWithValue("@DESENDFRN", objInserir.DESENDFRN);
            command.Parameters.AddWithValue("@DESCIDFRN", objInserir.DESCIDFRN);
            command.Parameters.AddWithValue("@DESESTAFRN", objInserir.DESESTAFRN);
            command.Parameters.AddWithValue("@CODFRNPRD", objInserir.CODFRNPRD);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().ativarFornecedor();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODFRNPRD", objInserir.CODFRNPRD);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().desativarFornecedor();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODFRNPRD", objInserir.CODFRNPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterFornecedor> obterFornecedor(CadastroFornecedorModel.InserirCadastroFornecedor objInserir)
        {
            var retorno = new List<obterFornecedor>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroFornecedorDALSQL().obterFornecedor(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESFRNPRD))
                command.Parameters.AddWithValue("@DESFRNPRD", objInserir.DESFRNPRD); 
            if (objInserir.CODFRNPRD > 0)
                command.Parameters.AddWithValue("@CODFRNPRD", objInserir.CODFRNPRD);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterFornecedor {
                    CODFRNPRD = dr.GetInt32(0)
                    , DESFRNPRD = dr.GetString(1)
                    , DATCAD = dr.GetString(2)
                    , DATDST = dr.IsDBNull(3) ? "" : dr.GetString(3)
                    , TELCTOFRN = dr.GetString(4)
                    , TELCTOFRNSEC = dr.GetString(5)
                    , NOMRSPFRN = dr.GetString(6)
                    , DESENDFRN = dr.GetString(7)
                    , DESCIDFRN = dr.GetString(8)
                    , DESESTAFRN = dr.GetString(9)
                });
            }
            return retorno;
        }
    }
}
