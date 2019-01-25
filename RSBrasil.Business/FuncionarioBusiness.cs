using RSBrasil.Data;
using RSBrasil.Model.Interface.Data;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class FuncionarioBusiness
    {
        private IRepositorioBase<Funcionario> repositorioFuncionario = new Repositorio<Funcionario>();

        public List<Funcionario> ListarFuncionarios()
        {
            List<Funcionario> lista = new List<Funcionario>();
            lista = repositorioFuncionario.Listar();
            return lista;
        }

        public void Inserir(Funcionario funcionario)
        {
            /*if (funcionario.Invalid)
            {
                repositorioFuncionario.Inserir(funcionario);
            }*/
        }

        public Funcionario LocalizarFuncionario(int Id)
        {
            if(Id > 0)
            {
                Funcionario funcionario = repositorioFuncionario.PesquisarPorId(Id);
                return funcionario;
            }
            else
            {
                return null;
            }
        }
    }
}
