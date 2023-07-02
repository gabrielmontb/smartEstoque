using CadastroProdutosTO;
using CadastroVendasTO;
using Dapper;
using Npgsql;
using SmartEstoque.Class;
using System.Collections.Generic;

namespace SmartEstoque.Business
{
    public class CadastroVendasDAL
    {
        public bool inserirVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().inserirVendas();
            var command = new NpgsqlCommand(query, conn);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().alterarVendas();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESTIPPRD", objInserir.DESTIPPRD);
            command.Parameters.AddWithValue("@CODGRPPRD", objInserir.CODGRPPRD);
            command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool ativarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().ativarVendas();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().desativarVendas();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODTIPPRD", objInserir.CODTIPPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterVendas> obterVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            var retorno = new List<obterVendas>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().obterVendas(objInserir);
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
                retorno.Add(new obterVendas { 
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
        public obterProdutosVendas obterProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            var retorno = new List<obterProdutosVendas>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().obterProdutos(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (objInserir.CODORDRMS > 0)
                command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS); 
            if (objInserir.CODBARPRD > 0)
                command.Parameters.AddWithValue("@CODBARPRD", objInserir.CODBARPRD);     
            if (!string.IsNullOrEmpty(objInserir.DESPRD))
                command.Parameters.AddWithValue("@DESPRD", objInserir.DESPRD);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterProdutosVendas
                {
                    CODPRD = dr.GetInt32(0),
                    DESPRD = dr.GetString(1),
                    VLRUNTPRD = dr.GetDecimal(2),
                    CODORDRMS = dr.GetInt32(3),
                    CODMODPRD = dr.GetInt32(4),
                    QUANTIDADE = dr.GetInt32(5)
                });
            }
            return retorno.FirstOrDefault();
        }
    }
}
