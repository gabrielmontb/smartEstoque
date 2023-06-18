using Dapper;
using SmartEstoque.Class;

namespace CadastroProdutosTO
{
    public class obterProdutos
    {
        public int CODPRD { get; set; }
        public string DESPRD { get; set; }
        public int CODMODPRD { get; set; }
        public int CODORDRMS { get; set; }
        public decimal VLRUNTPRD { get; set; }
        public decimal DESPESPRD { get; set; }
        public string DATVNCPRD { get; set; }
        public string DATVNDPRD { get; set; }
        public string DATCAD { get; set; }
        public string DESMODPRD { get; set; }
    }
}
