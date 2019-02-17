using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoBeneficios : ModelBase
    {
        public HistoricoBeneficios()
        {

        }

        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdTipoBeneficios { get; set; }
    }
}
