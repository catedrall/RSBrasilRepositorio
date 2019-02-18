using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace RSBrasil.Model.DTOs
{
    public class AfastamentoMedicoDTO : Notifiable, ICommand
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Fim afastamento")]
        public DateTime? DataFimAfastamento { get; set; }
        [Display(Name = "Início afastamento")]
        public DateTime? DataInicioAfastamento { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdTipoAfastamento { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.Descricao, "Descricao", "Descricao é obrigatória")
                .IsNotNullOrEmpty(this.DataInicioAfastamento.Value.ToString(), "DataInicioAfastamento", "Início afastamento é obrigatório")
            );
        }
    }
}
