using Dapper;
using SmartEstoque.Class;

namespace CadastroVendasTO
{
    public class obterVendas
    {
        public int CODVNDPRD { get; set; }

        public string DATCAD { get; set; }

        public int CODTIPPAG { get; set; }

        public string VLRVND { get; set; }

        public string TIPOPAGAMENTO { get; set; }
    } 
    public class obterProdutosVendas
    {
        public int CODPRD { get; set; }

        public string DESMODPRD { get; set; }

        public decimal VLRUNTPRD { get; set; }

        public int CODORDRMS { get; set; }

        public int CODMODPRD { get; set; }

        public decimal QUANTIDADE { get; set; }

        public int INDPESQTD { get; set; }
    }   
    public class obterRelacaoProdutos
    {
        public int CODORDRMS { get; set; }

        public string DESMODPRD { get; set; }

        public decimal QUANTIDADE { get; set; }

        public decimal VLRUNTPRD { get; set; }
    }
}
