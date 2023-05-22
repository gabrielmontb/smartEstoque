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
        public string TELCTOFRN { get; set; }
        public string TELCTOFRNSEC { get; set; }
        public string NOMRSPFRN { get; set; }
        public string DESENDFRN { get; set; }
        public string DESCIDFRN { get; set; }
        public string DESESTAFRN { get; set; }
    }
}
