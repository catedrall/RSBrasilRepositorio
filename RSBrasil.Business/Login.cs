using RSBrasil.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class Login
    {
        //public List<Telas> VerificaLogin(string usuario, string senha)
        public string VerificaLogin(string usuario, string senha)
        {
            var Validacao = new Data.Login();
            var funcionario = Validacao.VerificaLogin(usuario, senha);

            if (funcionario.IdPerfilAcesso > 0)
            {
                //return Validacao.GetTelasPerfilAcesso(funcionario.IdPerfilAcesso);
                return String.Empty;
            }
            else
            {
                //return new List<Telas>();
                return String.Empty;
            }
        }
    }
}
