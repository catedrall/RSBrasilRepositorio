using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RSBrasil.Model.DTOs
{
    public class ClienteDTO : Notifiable, ICommand
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public int? IdContrato { get; set; }

        private Regex regex = new Regex(@"^[1-9]{2}\-[2-9][0-9]{7,8}$");
        
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.CNPJ, 17, "CNPJ", "CNPJ inválido")
                .IsTrue(ValidaCNPJ(), "CNPJ", "Digite um CNPJ válido")
                .IsEmail(this.Email, "Email", "E-mail inválido")
                .IsNotNullOrEmpty(this.RazaoSocial, "RazaoSocial", "Razao social é obrigatória")
                .HasMinLen(this.RazaoSocial, 10, "RazaoSocial", "RazaoSocial digite um nome válido")
                .IsNotNullOrEmpty(this.Contato, "Contato", "Contato é obrigatório")
                .HasMinLen(this.Contato, 10, "Contato", "Contato digite um nome válido")
                .IsNotNullOrEmpty(this.Telefone, "Telefone", "Telefone é obrigatória")
                .IsTrue(ValidaTelefone(), "Telefone", "Digite um Telefone válido")
            );
        }

        public bool ValidaTelefone()
        { 
            bool verifica = this.regex.IsMatch(this.Telefone);
            if (verifica)
            {
                this.Telefone = FormataPropriedade(this.Telefone);
            }
            return verifica;
        }

        public string FormataPropriedade(string valor)
        {
            return valor = valor.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
        }

        public bool ValidaCNPJ()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            this.CNPJ = this.CNPJ.Trim();
            this.CNPJ = this.CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");

            if (this.CNPJ.Length != 14)
                return false;

            tempCnpj = this.CNPJ.Substring(0, 12);
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
            return this.CNPJ.EndsWith(digito);
        }
    }
}
