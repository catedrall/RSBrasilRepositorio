using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBRasil.Model.Entidades
{
    public class Telas : ModelBase
    {
        public string Descricao { get; set; }
        public string Telascol { get; set; }
        public int? Ativa { get; set; }
        public int IdTelas { get; set; }
    }
}
