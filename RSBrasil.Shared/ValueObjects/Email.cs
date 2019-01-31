using Flunt.Notifications;
using Flunt.Validations;

namespace RSBrasil.Shared.ValueObjects
{
    public class Email : Notifiable
    {
        public string Endereco { get; private set; }

        public Email(string _endereco)
        {
            this.Endereco = _endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.Endereco, "Nome.PrimeiroNome", "E-mail é obrigatório")
                .IsEmail(this.Endereco, "Email.Endereco", "E-mail inválido")
                .IsTrue(ValidaEmail(), "Email.Endereco", "E-mail inválido")
            );

        }

        public bool ValidaEmail()
        {
            if (this.Notifications.Count == 0)
                return true;
            else
                return false;
        }
    }
}
