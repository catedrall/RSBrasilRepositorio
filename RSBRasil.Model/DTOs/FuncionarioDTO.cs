﻿using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Model.DTOs
{
    public class FuncionarioDTO : Notifiable, ICommand
    {
        public int Id { get; set; }
        public string CarteiraMotorista { get; set; }
        public string CarteiraTrabalho { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int ColaboradorUniformeIdColaborador { get; set; }
        public bool Ativo { get; set; }
        public int Sexo { get; set; }
        public int EstadoCivil { get; set; }
        public int RacaCor { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Nacionalidade { get; set; }
        public int NacionalidadeUf { get; set; }
        public int Escolaridade { get; set; }
        public bool Deficiencia { get; set; }
        public string DeficienciaObservacao { get; set; }
        public string Banco { get; set; }
        public int TipoConta { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public DateTime UltimoPeriodoFeriasInicio { get; set; }
        public DateTime UltimoPeriodoFeriasFim { get; set; }
        public int FeriasGozadas { get; set; }
        public int FeriasGozar { get; set; }
        public DateTime DataLimiteFerias { get; set; }
        public int IdFuncionarioDocumento { get; set; }
        public int IdCargo { get; set; }
        public int IdEndereco { get; set; }
        public int IdFuncionario { get; set; }
        public int IdPerfilAcesso { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.CarteiraMotorista, "CarteiraMotorista", "CNH é obrigatória")
                .IsNotNullOrEmpty(this.CarteiraTrabalho, "CarteiraTrabalho", "Carteira de trabalho é obrigatória")
                .IsNotNullOrEmpty(this.CPF, "CPF", "CPF é obrigatório")
                .IsTrue(ValidaCpf(), "CPF", "Digite um CPF válido")
                .IsNotNullOrEmpty(this.Login, "Login", "Login é obrigatório")
                .HasMinLen(this.Login, 6, "Login", "O login não pode ter menos que 6 caracteres")
                .HasMaxLen(this.Login, 20, "Login", "O login não pode ter mais que 20 caracteres")
                .IsNull(Nome, "Nome", "Nome é obrigatório")
                .IsNotNullOrEmpty(this.RG, "RG", "RG é obrigatório")
                .IsNotNullOrEmpty(this.Senha, "Senha", "Senha é obrigatória")
                .HasMinLen(this.Login, 8, "Senha", "O senha não pode ter menos que 8 caracteres")
                .HasMaxLen(this.Login, 20, "Senha", "O senha não pode ter mais que 20 caracteres")
                .IsNotNullOrEmpty(this.DataNascimento.ToString(), "DataNascimento", "Data de nascimento é obrigatória")
                .IsNotNullOrEmpty(this.Cep, "Cep", "Cep é obrigatória")
                .HasMinLen(this.Cep, 8, "Cep", "Cep inválido")
                .IsNotNullOrEmpty(this.Logradouro, "Logradouro", "Logradouro é obrigatória")
                .IsNotNullOrEmpty(this.Numero, "Numero", "Numero é obrigatória")
                .IsNotNullOrEmpty(this.Bairro, "Bairro", "Bairro é obrigatória")
                .IsNotNullOrEmpty(this.Cidade, "Cidade", "Cidade é obrigatória")
                //.IsNotNullOrEmpty(this.NacionalidadeUf, "UF", "Estado é obrigatória")
            );
        }

        public bool ValidaCpf()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            tempCpf = CPF.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return CPF.EndsWith(digito);
        }
    }
}
