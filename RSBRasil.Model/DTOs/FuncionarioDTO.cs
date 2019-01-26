using Flunt.Notifications;
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
        public string NacionalidadeUf { get; set; }
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

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.CarteiraMotorista, "CarteiraMotorista", "CNH é obrigatória")
                .IsNotNullOrEmpty(this.CarteiraTrabalho, "CarteiraTrabalho", "Carteira de trabalho é obrigatória")
                .IsNotNullOrEmpty(this.CPF, "CPF", "CPF é obrigatório")
                .IsNotNullOrEmpty(this.Login, "Login", "Login é obrigatório")
                .HasMinLen(this.Login, 6, "Login", "O login não pode ter menos que 6 caracteres")
                .HasMaxLen(this.Login, 20, "Login", "O login não pode ter mais que 20 caracteres")
                .IsNull(Nome, "Nome", "Nome é obrigatório")
                .IsNotNullOrEmpty(this.RG, "RG", "RG é obrigatório")
                .IsNotNullOrEmpty(this.Senha, "Senha", "Senha é obrigatória")
                .HasMinLen(this.Login, 8, "Senha", "O senha não pode ter menos que 8 caracteres")
                .HasMaxLen(this.Login, 20, "Senha", "O senha não pode ter mais que 20 caracteres")
                .IsNotNullOrEmpty(this.DataNascimento.ToString(), "DataNascimento", "Data de nascimento é obrigatória")
            );
        }
    }
}
