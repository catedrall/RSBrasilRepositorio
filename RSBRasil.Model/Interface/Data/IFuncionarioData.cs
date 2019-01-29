using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Model.Interface.Data
{
    public interface IFuncionarioData
    {
        int InserirFuncionario(Funcionario funcionario);
        Funcionario BuscarFuncionario(int Id);
        int EditarFuncionario(Funcionario funcionario);
    }
}
