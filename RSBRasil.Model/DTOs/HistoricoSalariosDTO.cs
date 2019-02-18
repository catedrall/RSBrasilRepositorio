using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace RSBrasil.Model.DTOs
{
    public class HistoricoSalariosDTO : Notifiable, ICommand
    {
        public int Id { get; set; }

        [Display(Name = "Data Pagamento")]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Salario")]
        public decimal Salario { get; set; }

        [Display(Name = "Funcionário")]
        public int IdFuncionario { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.DataPagamento.ToString(), "DataPagamento", "Data falta é obrigatória")
                .IsNotNullOrEmpty(this.IdFuncionario.ToString(), "IdFuncionario", "Selecione um funcionário")
                .IsNotNullOrEmpty(this.Salario.ToString(), "Salario", "Salário é obrigatório")
            );
        }
    }
}
