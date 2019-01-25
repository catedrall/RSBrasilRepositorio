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

        public Cliente(string cNPJ, string contato, Email email, string nomeFantasia, string razaoSocial, string telefone, int? idContrato)
        {
            CNPJ = FormataPropriedade(cNPJ);
            Contato = contato;
            Email = email.Endereco;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            Telefone = FormataPropriedade(telefone);
            IdContrato = idContrato;
        }
        
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public int? IdContrato { get; set; }

        public string FormataPropriedade(string valor)
        {
            return valor = valor.Replace(".", "").Replace("-", "").Replace("/","").Replace(" ", "");
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
            CNPJ = CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");

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
