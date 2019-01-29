using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoDeFalta
    {
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataFalta { get; set; }
        public DateTime? DataInclusao { get; set; }
        public int? Funcionario_ColaboradorUniforme_IdColaborador { get; set; }
        public int? Funcionario_IdFuncionario { get; set; }
        public int? IdCliente { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdHistoricoDeFalta { get; set; }
    }
}
