using Dapper;
using SmartEstoque.Class;

namespace CadastroGrupoProdutosTO
{
    public class obterGrupoProdutos
    {
        public int CODGRPPRD { get; set; }

        public int INDPESQTD { get; set; }

        public string DESGRPPRD { get; set; }

        public string DATCAD { get; set; }

        public string? DATDST { get; set; }
    }
}
