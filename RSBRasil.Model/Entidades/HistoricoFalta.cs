using RSBrasil.Shared.Model;
using RSBrasil.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoFalta : ModelBase
    {
        public DateTime DataFalta { get; set; }
        public int? IdCliente { get; set; }
        public int IdFuncionario { get; set; }
    }
}
