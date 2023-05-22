using Dapper;
using SmartEstoque.Class;

namespace CadastroOrdemRemessaTO
{
    public class obterOrdemRemessa
    {
        public int CODSTAORDRMS { get; set; }

        public string DESSTAORDRMS { get; set; }

        public string DATCAD { get; set; }

        public string? DATDST { get; set; }
    }
}
