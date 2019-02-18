using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoPunicao : ModelBase
    {
        public string Descricao { get; set; }
        public DateTime? DataPunicao { get; set; }
        public int? IdFuncionario { get; set; }
    }
}
