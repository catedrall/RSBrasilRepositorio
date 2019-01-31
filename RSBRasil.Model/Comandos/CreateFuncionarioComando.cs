using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Model.Comandos
{
    public class CreateFuncionarioComando
    {
        public string CarteiraMotorista { get; set; }
        public string CarteiraTrabalho { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string RG { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
    }
}
