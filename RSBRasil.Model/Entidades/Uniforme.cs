using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class Uniforme : ModelBase
    {
        public Uniforme()
        {

        }

        public string Descricao { get; set; }
        public DateTime? DataCompra { get; set; }
        public int? Duracao { get; set; }
    }
}
