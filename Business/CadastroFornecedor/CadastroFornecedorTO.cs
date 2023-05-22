using Dapper;
using SmartEstoque.Class;

namespace CadastroFornecedorTO
{
    public class obterFornecedor
    {
        public int CODGRPPRD { get; set; }

        public string DESGRPPRD { get; set; }

        public string DATCAD { get; set; }

        public string? DATDST { get; set; }
    }
}
