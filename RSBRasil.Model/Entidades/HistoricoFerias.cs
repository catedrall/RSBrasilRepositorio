using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoFerias : ModelBase
    {
        public string IdFuncionario { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataInicio { get; set; }
        public int? IdHistoricoDeFerias { get; set; }
        public double? PeriodoCompleto { get; set; }
    }
}
