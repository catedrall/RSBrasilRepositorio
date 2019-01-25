using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class TipoHistoricoBeneficio
    {
        public string Descricao { get; set; }
        public int? HistBeneficios_Func_ColabUniforme_IdColab { get; set; }
        public int? HistoricoBeneficios_Funcionario_IdFuncionario { get; set; }
        public int? HistoricoBeneficios_IdHistoricoPagamentoVAVR { get; set; }
        public int? IdTipoHistoricoBeneficio { get; set; }
    }
}
