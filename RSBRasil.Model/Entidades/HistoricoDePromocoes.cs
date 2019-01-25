using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoDePromocoes
    {
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataPromocao { get; set; }
        public int? Funcionario_IdFuncionario { get; set; }
        public int? IdCargo { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdHistoricoDePromocoes { get; set; }
    }
}
