using Dapper;
using SmartEstoque.Class;

namespace CadastroOrdemRemessaTO
{
    public class obterOrdemRemessa
    {
        public int CODORDRMS { get; set; }
        public int CODMODPRD { get; set; }
        public string DESMODPRD { get; set; }
        public int CODFRNPRD { get; set; }
        public string DESFRNPRD { get; set; }
        public string DATCAD { get; set; }
        public string DATPRVENT { get; set; }
        public int CODSTAORDRMS { get; set; }
        public string DESSTAORDRMS { get; set; }
        public int QDEPRD { get; set; }
        public decimal VLRLOTRMS { get; set; }
        public int NUMLOTRMS { get; set; }
        public string CODBARPRD { get; set; }
        public string DATFIM { get; set; }
        public string DESORDRMS { get; set; }
        public string CODNOTFSC { get; set; }
        public int INDPESQTD { get; set; }
        public string DATVNCPRD { get; set; }
        public decimal VLRUNTPRD { get; set; }
        public decimal DESPESPRD { get; set; }
        public decimal DESPESPRDVND { get; set; }
        public int QDEPRDVND { get; set; }
    }
}
