using Dapper;
using SmartEstoque.Class;

namespace CadastroVendasTO
{
    public class obterVendas
    {
        public int CODTIPPRD { get; set; }

        public string DESTIPPRD { get; set; }

        public int CODGRPPRD { get; set; }

        public string DESGRPPRD { get; set; }

        public string DATCAD { get; set; }

        public string? DATDST { get; set; }
    } 
    public class obterProdutosVendas
    {
        public int CODPRD { get; set; }

        public string DESMODPRD { get; set; }

        public decimal VLRUNTPRD { get; set; }

        public int CODORDRMS { get; set; }

        public int CODMODPRD { get; set; }

        public int QUANTIDADE { get; set; }

        public int INDPESQTD { get; set; }
    }   
    public class obterRelacaoProdutos
    {
        public int CODORDRMS { get; set; }

        public string DESMODPRD { get; set; }

        public int QUANTIDADE { get; set; }

        public decimal VLRUNTPRD { get; set; }
    }
}
