using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;

namespace RSBrasil.Shared.ValueObjects
{
    public class NomeJuridica : Notifiable
    {
        public NomeJuridica(string _primeiro)
        {
            this.PrimeiroNome = _primeiro;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.PrimeiroNome, "Nome.PrimeiroNome", "Nome é um campo obrigatório")
                .HasMinLen(this.PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter pelo menos 3 caracteres")
            );
        }

        public string PrimeiroNome { get; private set; }
    }
}
