using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;

namespace RSBrasil.Shared.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string _primeiro, string _ultimo)
        {
            this.PrimeiroNome = _primeiro;
            this.UltimoNome = _ultimo;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.PrimeiroNome, "Nome.PrimeiroNome", "Nome é um campo obrigatório")
                .HasMinLen(this.PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(this.UltimoNome, "Nome.UltimoNome", "Sobrenome é um campo obrigatório")
            );
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
