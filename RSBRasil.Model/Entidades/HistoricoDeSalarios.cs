using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class HistoricoDeSalarios : ModelBase
    {
        public HistoricoDeSalarios()
        {

        }

        public int IdFuncionario { get; set; }

        public decimal Salario { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}
