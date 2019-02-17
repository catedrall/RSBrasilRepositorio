using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using RSBrasil.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace RSBrasil.Model.DTOs
{
    public class ClienteDTO : Notifiable, ICommand
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Nome fantasia")]
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public int? IdContrato { get; set; }
        
        /// Endereco
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }

        private Regex regex = new Regex(@"^[1-9]{2}\-[2-9][0-9]{7,8}$");
        //private Regex regex = new Regex(@"^([1-9]{2}) [2-9]\-[0-9]{7,8}$");

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
                .IsNotNullOrEmpty(this.Cep, "Cep", "Cep é obrigatória")
                .HasMinLen(this.Cep, 8, "Cep", "Cep inválido")
                .IsNotNullOrEmpty(this.Logradouro, "Logradouro", "Logradouro é obrigatória")
                .IsNotNullOrEmpty(this.Numero, "Numero", "Numero é obrigatória")
                .IsNotNullOrEmpty(this.Bairro, "Bairro", "Bairro é obrigatória")
                .IsNotNullOrEmpty(this.Cidade, "Cidade", "Cidade é obrigatória")
                .IsNotNullOrEmpty(this.UF, "UF", "Estado é obrigatória")
            );
        }

        public bool ValidaTelefone()
        { 
            bool verifica = this.regex.IsMatch(this.Telefone);
            if (verifica)
            {
                this.Telefone = Mascara.FormatarPropriedade(this.Telefone);
            }
            return verifica;
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
            this.CNPJ = Mascara.FormatarPropriedade(CNPJ);

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
