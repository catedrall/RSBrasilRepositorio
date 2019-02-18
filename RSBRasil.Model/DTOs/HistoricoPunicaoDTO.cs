using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using RSBrasil.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace RSBrasil.Model.DTOs
{
    public class HistoricoPunicaoDTO : Notifiable, ICommand
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Data punição")]
        public DateTime? DataPunicao { get; set; }
        [Display(Name = "Funcionário")]
        public int? IdFuncionario { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.Descricao, "Descricao", "Descricao é obrigatória")
                .IsNotNullOrEmpty(this.IdFuncionario.ToString(), "IdFuncionario", "Selecione um funcionário")
                .IsNotNullOrEmpty(this.DataPunicao.ToString(), "DataPunicao", "Data punição é obrigatório")
            );
        }
    }
}
