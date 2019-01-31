using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class Contratos : ModelBase
    {
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? PeriodoAte { get; set; }
        public DateTime? PeriodoDe { get; set; }
        public int Ativo { get; set; }
        public int? Cliente_IdCliente { get; set; }
        public int? IdCliente { get; set; }
    }
}
