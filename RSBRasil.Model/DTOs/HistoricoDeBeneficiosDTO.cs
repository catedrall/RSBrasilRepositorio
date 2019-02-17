using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace RSBrasil.Model.DTOs
{
    public class HistoricoDeBeneficiosDTO : Notifiable, ICommand
    {
        public int Id { get; set; }

        [Display(Name = "Data Pagamento")]
        public DateTime DataPagamento { get; set; }
        
        [Display(Name = "Funcionário")]
        public int IdFuncionario { get; set; }

        public int IdTipoBeneficio { get; set; }
        [Display(Name = "Beneficios")]
        
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.DataPagamento.ToString(), "DataPagamento", "Data de pagamento obrigatória")
                .IsNotNullOrEmpty(this.IdFuncionario.ToString(), "IdFuncionario", "Funcionário é obrigatório")
                .IsNotNullOrEmpty(this.IdTipoBeneficio.ToString(), "IdTipoBeneficio", "Beneficio é obrigatório")
            );
        }
    }
}
