using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoExameMedico : ModelBase
    {
        public DateTime? DataAusencia { get; set; }
        public int? DiasAusentes { get; set; }
        public int? IdDocumentos { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdHistoricoDeExameMedico { get; set; }
    }
}
