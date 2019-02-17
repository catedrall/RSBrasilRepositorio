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
        [Display(Name = "Data falta")]
        public DateTime DataFalta { get; set; }
        [Display(Name = "Cliente")]
        public int? IdCliente { get; set; }
        [Display(Name = "Funcionário")]
        public int IdFuncionario { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.DataFalta.ToString(), "DataFalta", "Data falta é obrigatória")
            );
        }
    }
}
