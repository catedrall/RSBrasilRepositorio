using System;
using System.Collections.Generic;
using System.Text;

namespace RSBRasil.Model.Entidades
{
    public class Afastamentomedico
    {
        public string Descricao { get; set; }
        public DateTime? DataAtuaizacao { get; set; }
        public DateTime? DataFimAfastamento { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataInicioAfastamento { get; set; }
        public int? Funcionario_ColaboradorUniforme_IdColaborador { get; set; }
        public int? Funcionario_IdFuncionario { get; set; }
        public int? IdAfastamentoMedico { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdTipoAfastamento { get; set; }
    }
}
