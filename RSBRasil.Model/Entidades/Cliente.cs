using Flunt.Notifications;
using RSBrasil.Shared.Model;
using RSBrasil.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class Cliente : ModelBase
    {
        public Cliente()
        {

        }

        public Cliente(string CNPJ, string contato, Email email, string nomeFantasia, string razaoSocial, string telefone, string cep, 
                        string logradouro, string numero, string complemento, string bairro, string cidade, string uf, string pais, int? idContrato)
        {
            CNPJ = Mascara.FormatarPropriedade(CNPJ);
            Contato = contato;
            Email = email.Endereco;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            Telefone = Mascara.FormatarPropriedade(telefone);
            IdContrato = idContrato;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            Pais = pais;
        }
        
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public int? IdContrato { get; set; }
        /// Endereco
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        

        public void ColcarMascara()
        {
            this.Telefone = Mascara.MascaraTelefones(this.Telefone);
            this.CNPJ = Mascara.MascaraCnpj(this.CNPJ);
        }

        public bool ValidaCNPJ()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            CNPJ = CNPJ.Trim();
            CNPJ = Mascara.FormatarPropriedade(CNPJ);

            if (CNPJ.Length != 14)
                return false;

            tempCnpj = CNPJ.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return CNPJ.EndsWith(digito);
        }
    }
}
