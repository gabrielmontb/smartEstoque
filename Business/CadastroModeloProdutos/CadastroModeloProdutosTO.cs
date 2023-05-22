using Dapper;
using SmartEstoque.Class;

namespace CadastroModeloProdutosTO
{
    public class obterModeloProdutos
    {
        public int CODMODPRD { get; set; }
        public string DESMODPRD { get; set; }
        public int CODTIPPRD { get; set; }
        public string DESTIPPRD { get; set; }
        public string DATCAD { get; set; }
        public string? DATDST { get; set; }
    }
}
