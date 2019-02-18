using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoPrecos : ModelBase
    {
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int? Contratos_IdContrato { get; set; }
        public int? IdContrato { get; set; }
        public int? IdHistoricoDePrecos { get; set; }
        public double? Valor { get; set; }
    }
}
