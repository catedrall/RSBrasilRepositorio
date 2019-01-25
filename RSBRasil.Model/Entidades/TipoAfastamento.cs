using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class TipoAfastamento
    {
        public string Descricao { get; set; }
        public int? AfastamentoMedico_IdAfastamentoMedico { get; set; }
        public int? IdTipoAfastamento { get; set; }
    }
}
