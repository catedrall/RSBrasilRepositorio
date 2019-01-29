using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RSBRasil.Model.Entidades;

namespace RSBrasil.Data.Entidades
{
    public class FuncionarioData : IFuncionarioData
    {

        //private SistemaContext contexto = new SistemaContext();

        public Funcionario BuscarFuncionario(int Id)
        {
            /*Funcionario funcionario = contexto.
            throw new NotImplementedException();*/
            return null;
        }

        public int EditarFuncionario(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public int InserirFuncionario(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
