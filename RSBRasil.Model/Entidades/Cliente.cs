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

        public Cliente(string _CNPJ, string contato, Email email, string nomeFantasia, string razaoSocial, string telefone, int? idContrato)
        {
            this.CNPJ = Mascara.FormatarPropriedade(_CNPJ);
            this.Contato = contato;
            this.Email = email.Endereco;
            this.NomeFantasia = nomeFantasia;
            this.RazaoSocial = razaoSocial;
            this.Telefone = Mascara.FormatarPropriedade(telefone);
            this.IdContrato = idContrato;
        }
        
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public int? IdContrato { get; set; }
        

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
