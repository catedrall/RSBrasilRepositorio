using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Shared.ValueObjects
{
    public static class Mascara
    {
        public static string MascaraCnpj(string cnpj)
        {
            string mascaraCnpj = cnpj.Substring(0, 2) + "." + cnpj.Substring(2, 3) + "." + cnpj.Substring(5, 3) + "/" + cnpj.Substring(8, 4) + "-" + cnpj.Substring(12, 2);
            return mascaraCnpj;
        }

        public static string MascaraTelefones(string numero)
        {
            string mascara = String.Empty;
            if (numero.Substring(2, 1).Equals("9"))
                mascara = "(" + numero.Substring(0, 2) + ") " + numero.Substring(2, 5) + "-" + numero.Substring(7, 4);
            else
                mascara = "(" + numero.Substring(0, 2) + ") " + numero.Substring(2, 4) + "-" + numero.Substring(6, 4);
            return mascara;
        }

        public static string MascaraCpf(string cpf)
        {
            string mascaraCpf = cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." + cpf.Substring(6, 3) + "-" + cpf.Substring(9, 2);
            return mascaraCpf;
        }

        public static string FormatarPropriedade(string valor)
        {
            string retorno = valor.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Replace("(","").Replace(")", "");
            return retorno;
        }
    }
}
