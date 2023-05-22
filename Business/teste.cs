using Dapper;
using Npgsql;
using SmartEstoque.Class;

namespace SmartEstoque.Business
{
    public class teste
    {
        public bool testeconexao()
        {
            using var conn = new DbConnection().Connection;
            string query = "insert into teste (id,descricao) values ((select max(id)+1 from teste), @DESSTAORDRMS)";
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@DESSTAORDRMS", "teste");
            command.ExecuteNonQuery();
            return true;
        }
    }
}
