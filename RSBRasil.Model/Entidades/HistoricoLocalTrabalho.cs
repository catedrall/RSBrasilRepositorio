using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoLocalTrabalho : ModelBase
    {
        public DateTime? DataFinalizacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public int? IdCliente { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdHistoricoDeLocalTrabalho { get; set; }
    }
}
