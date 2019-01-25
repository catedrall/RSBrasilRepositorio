using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class FuncionarioUniforme
    {
        public DateTime? DataEmprestimo { get; set; }
        public int? Funcionario_ColaboradorUniforme_IdColaborador { get; set; }
        public int? Funcionario_IdFuncionario { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdUniforme { get; set; }
        public int? Uniforme_IdUniforme { get; set; }
    }
}
