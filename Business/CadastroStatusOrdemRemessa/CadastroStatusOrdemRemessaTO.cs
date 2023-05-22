using Dapper;
using SmartEstoque.Class;

namespace CadastroStautsOrdemRemessaTO
{
    public class obterStatusOrdemRemessa
    {
        public int CODSTAORDRMS { get; set; }

        public string DESSTAORDRMS { get; set; }

        public string DATCAD { get; set; }

        public string? DATDST { get; set; }
    }
}
