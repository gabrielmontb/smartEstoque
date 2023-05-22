using Npgsql;

namespace SmartEstoque.Class
{
    public class DbConnection : IDisposable
    {
        public NpgsqlConnection Connection { get; set; }

        public DbConnection()
        {
            Connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=SmartEstoque;User id=postgres;Password=123456;");
            Connection.Open();
        }
        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
