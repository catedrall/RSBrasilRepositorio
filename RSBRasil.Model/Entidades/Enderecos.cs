using RSBrasil.Shared.Model;
using RSBrasil.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class Enderecos : ModelBase
    {
        public Enderecos(string cep)
        {
            this.Cep = Mascara.FormatarPropriedade(cep);
        }

        //public string Bairro { get; set; }
        //public string Cidade { get; set; }
        //public string Complemento { get; set; }
        //public string Logradouro { get; set; }
        //public string UF { get; set; }
        //public DateTime? DataAtualizacao { get; set; }
        //public DateTime? Matriz { get; set; }
        //public int? Complemento_copy1 { get; set; }
        //public int? Cliente_IdCliente { get; set; }
        //public int? Funcionario_ColaboradorUniforme_IdColaborador { get; set; }
        //public int? Funcionario_IdFuncionario { get; set; }
        //public int? IdEnderecos { get; set; }
        //public int? IdTipoEndereco { get; set; }
        //public int? Numero { get; set; }

        public int Idclientefuncionario { get; set; }
        public bool Residenciapropria { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }
    }
}
