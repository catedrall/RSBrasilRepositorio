using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoDeFerias
    {
        public string IdFuncionario { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataInicio { get; set; }
        public int? Funcionario_ColaboradorUniforme_IdColaborador { get; set; }
        public int? Funcionario_IdFuncionario { get; set; }
        public int? IdHistoricoDeFerias { get; set; }
        public double? PeriodoCompleto { get; set; }
    }
}
