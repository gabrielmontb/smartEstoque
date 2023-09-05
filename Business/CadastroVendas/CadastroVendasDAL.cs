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
        public bool ConcluirVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().ConcluirVendas();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@codtippag", objInserir.CODTIPPAG);
            command.Parameters.AddWithValue("@vlrvnd", objInserir.VLRVND);
            command.Parameters.AddWithValue("@codvndprd", objInserir.CODVNDPRD);
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
        public bool atualizaEstoque(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().atualizaEstoque();
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
        public bool inserirProdutoVenda(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().inserirProdutoVenda();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODVNDPRD", objInserir.CODVNDPRD);
            command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS);
            command.Parameters.AddWithValue("@QDEPRDVND", objInserir.QDEPRDVND);
            command.Parameters.AddWithValue("@DESPESPRDVND", Convert.ToDecimal((objInserir.DESPESPRDVND != null? objInserir.DESPESPRDVND.Replace(".", ",") : 0)));
            return (command.ExecuteNonQuery() == 1);
        }  
        public bool atualizaOrdemRemessa(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().atualizaOrdemRemessa();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@QDEPRDVND", objInserir.QDEPRDVND);
            command.Parameters.AddWithValue("@DESPESPRDVND", Convert.ToDecimal((objInserir.DESPESPRDVND != null ? objInserir.DESPESPRDVND.Replace(".", ",") : 0)));
            command.Parameters.AddWithValue("@CODORDRMS", objInserir.CODORDRMS);
            return (command.ExecuteNonQuery() == 1);
        }   
        public bool removeCadastroVenda(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().removeCadastroVenda();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODVNDPRD", objInserir.CODVNDPRD);
            return (command.ExecuteNonQuery() == 1);
        }
        public bool validaVendaConcluida(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().validaVendaConcluida();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODVNDPRD", objInserir.CODVNDPRD);
            var retorno = command.ExecuteScalar();
            if (retorno == null) return false; else return true;
        }   
        public bool cadastrarCodigoVenda(int CODVNDPRD)
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().cadastrarCodigoVenda();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODVNDPRD", CODVNDPRD);
            return (command.ExecuteNonQuery() == 1);
        }    
        public int obterCodigoVenda()
        {
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().obterCodigoVenda();
            var command = new NpgsqlCommand(query, conn);
            var retorno = command.ExecuteScalar();
            if (retorno != null)
                return Convert.ToInt32(retorno);
            return 0;
        } 
        public List<obterVendas> obterVendas(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            var retorno = new List<obterVendas>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().obterVendas(objInserir);
            var command = new NpgsqlCommand(query, conn);
            if (objInserir.CODVNDPRD > 0)
                command.Parameters.AddWithValue("@CODVNDPRD", objInserir.CODVNDPRD);
            if (objInserir.CODTIPPAG > 0)
                command.Parameters.AddWithValue("@CODTIPPAG", objInserir.CODTIPPAG); 
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterVendas {
                    CODVNDPRD = dr.GetInt32(0),
                    DATCAD = dr.GetString(1),
                    CODTIPPAG = dr.IsDBNull(2) ? 0 : dr.GetInt32(2),
                    VLRVND = dr.IsDBNull(3) ? "R$0.00" : dr.GetString(3),
                    TIPOPAGAMENTO = dr.GetString(4)
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
                    VLRUNTPRD = dr.GetDecimal(0),
                    CODORDRMS = dr.GetInt32(1),
                    CODMODPRD = dr.GetInt32(2),
                    QUANTIDADE = dr.GetDecimal(3),
                    DESMODPRD = dr.GetString(4),
                    INDPESQTD = dr.GetInt32(5),
                });
            }
            return retorno.FirstOrDefault();
        }  
        public List<obterRelacaoProdutos> obterRelacaoProdutos(CadastroVendasModel.InserirCadastroVendas objInserir)
        {
            var retorno = new List<obterRelacaoProdutos>();
            using var conn = new DbConnection().Connection;
            string query = new CadastroVendasDALSQL().obterRelacaoProdutos();
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@CODVNDPRD", objInserir.CODVNDPRD); 
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                retorno.Add(new obterRelacaoProdutos
                {
                    CODORDRMS = dr.GetInt32(0),
                    DESMODPRD = dr.GetString(1),
                    QUANTIDADE = dr.GetDecimal(2),
                    VLRUNTPRD = dr.GetDecimal(3)
                });
            }
            return retorno;
        }
    }
}
