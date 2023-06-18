using CadastroProdutosTO;
using Dapper;
using Npgsql;
using SmartEstoque.Class;
using System.Collections.Generic;

namespace SmartEstoque.Business
{
    public class CadastroProdutosDAL
    {
        public bool inserirProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroProdutosDALSQL().inserirProdutos();
            var command = new NpgsqlCommand(query, conn);
            //command.Parameters.AddWithValue("@DESFRNPRD", objInserir.DESFRNPRD);
            //command.Parameters.AddWithValue("@TELCTOFRN", objInserir.TELCTOFRN);
            //command.Parameters.AddWithValue("@TELCTOFRNSEC", objInserir.TELCTOFRNSEC);
            //command.Parameters.AddWithValue("@NOMRSPFRN", objInserir.NOMRSPFRN);
            //command.Parameters.AddWithValue("@DESENDFRN", objInserir.DESENDFRN);
            //command.Parameters.AddWithValue("@DESCIDFRN", objInserir.DESCIDFRN);
            //command.Parameters.AddWithValue("@DESESTAFRN", objInserir.DESESTAFRN);
            return (command.ExecuteNonQuery() == 1);
        } 
        public bool alterarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroProdutosDALSQL().alterarProdutos(objInserir);
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESPRD", objInserir.DESPRD);
            command.Parameters.AddWithValue("@VLRUNTPRD", objInserir.VLRUNTPRD);
            command.Parameters.AddWithValue("@DESPESPRD", objInserir.DESPESPRD);
            if(!string.IsNullOrEmpty(objInserir.DATVNCPRD))
                command.Parameters.AddWithValue("@DATVNCPRD", objInserir.DATVNCPRD);
            if(objInserir.CODORDRMS > 0)
                command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS);
            else
                command.Parameters.AddWithValue("@CODPRD", objInserir.CODPRD);
            return (command.ExecuteNonQuery() > 0);
        }  
        public bool ativarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroProdutosDALSQL().ativarProdutos();
            var command = new NpgsqlCommand(query, conn);
            //command.Parameters.AddWithValue("@CODFRNPRD", objInserir.CODFRNPRD);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool desativarProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroProdutosDALSQL().desativarProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODPRD", objInserir.CODPRD);
            return (command.ExecuteNonQuery() == 1);
        } 
        public List<obterProdutos> obterProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
        {
            var retorno = new List<obterProdutos>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroProdutosDALSQL().obterProdutos(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(objInserir.DESPRD))
                command.Parameters.AddWithValue("@DESPRD", objInserir.DESPRD); 
            if (objInserir.CODPRD > 0)
                command.Parameters.AddWithValue("@CODPRD", objInserir.CODPRD);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterProdutos {
                    CODPRD = dr.GetInt32(0)
                    , DESPRD = dr.GetString(1)
                    , CODMODPRD = dr.GetInt32(2)
                    , CODORDRMS = dr.IsDBNull(3) ? 0 : dr.GetInt32(3)
                    , VLRUNTPRD = dr.GetDecimal(4)
                    , DESPESPRD = dr.GetDecimal(5)
                    , DATVNCPRD = dr.IsDBNull(6) ? "" : dr.GetString(6)
                    , DATVNDPRD = dr.IsDBNull(7) ? "" : dr.GetString(7)
                    , DATCAD = dr.GetString(8)
                    , DESMODPRD = dr.GetString(9)
                });
            }
            return retorno;
        }
    }
}
