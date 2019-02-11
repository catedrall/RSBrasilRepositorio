using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Shared.ValueObjects
{
    public class Endereco : ModelBase
    {
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
