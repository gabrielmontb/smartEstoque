using Dapper;
using SmartEstoque.Class;

namespace CadastroFornecedorTO
{
    public class obterFornecedor
    {
        public int CODFRNPRD { get; set; }

        public string DESFRNPRD { get; set; }

        public string DATCAD { get; set; }

        public string? DATDST { get; set; }
    }
}
