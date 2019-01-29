using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoDeExameMedico
    {
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataAusencia { get; set; }
        public DateTime? DataInclusao { get; set; }
        public int? DiasAusentes { get; set; }
        public int? Funcionario_ColaboradorUniforme_IdColaborador { get; set; }
        public int? Funcionario_IdFuncionario { get; set; }
        public int? IdDocumentos { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdHistoricoDeExameMedico { get; set; }
    }
}
