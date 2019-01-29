using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class Documentos
    {
        public string Documento { get; set; }
        public int? AfastamentoMedico_IdAfastamentoMedico { get; set; }
        public int? HistExameMedico_Func_ColabUniforme_IdCola { get; set; }
        public int? HistoricoDeExameMedico_Funcionario_IdFuncionario { get; set; }
        public int? HistoricoDeExameMedico_IdHistoricoDeExameMedico { get; set; }
        public int? HistoricoDeFalta_IdHistoricoDeFalta { get; set; }
        public int? HistoricoPunicoes_IdHistoricoPunicoes1 { get; set; }
        public int? IdDocumentos { get; set; }
        public int? IdTipoDocumento { get; set; }
    }
}
