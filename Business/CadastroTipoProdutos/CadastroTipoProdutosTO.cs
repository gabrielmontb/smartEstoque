using Dapper;
using SmartEstoque.Class;

namespace CadastroTipoProdutosTO
{
    public class obterTipoProdutos
    {
        public int CODTIPPRD { get; set; }

        public string DESTIPPRD { get; set; }

        public int CODGRPPRD { get; set; }

        public string DESGRPPRD { get; set; }

        public string DATCAD { get; set; }

        public string? DATDST { get; set; }
    } 
}
