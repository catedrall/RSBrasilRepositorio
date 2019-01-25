using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class ClienteBusiness
    {
        private IRepositorioBase<Cliente> repositorioCliente = new Repositorio<Cliente>();

        public void Inserir(Cliente cliente)
        {
            cliente.DataInclusao = DateTime.Now;
            repositorioCliente.Inserir(cliente);
        }

        public Cliente BuscaCliente(int Id)
        {
            if (Id > 0)
                return repositorioCliente.PesquisarPorId(Id);
            else
                return null;
        }

        public List<Cliente> ListarTodos()
        {
            return repositorioCliente.Listar();
        }

        public void ExcluirCliente(int Id)
        {
            if (Id > 0)
            {
                Cliente cliente = repositorioCliente.PesquisarPorId(Id);
                repositorioCliente.Excluir(cliente);
            }
        }

        public void EditarCliente(ClienteDTO cliente)
        {
            if (cliente != null)
            {
                Cliente local = repositorioCliente.PesquisarPorId(cliente.Id);
                local.CNPJ = cliente.CNPJ;
                local.Contato = cliente.Contato;
                local.DataAlteracao = DateTime.Now;
                local.Email = cliente.Email;
                local.IdContrato = cliente.IdContrato;
                local.NomeFantasia = cliente.NomeFantasia;
                local.RazaoSocial = cliente.RazaoSocial;
                local.Telefone = cliente.Telefone;
                repositorioCliente.Atualizar(local);
            }
        }
    }
}
