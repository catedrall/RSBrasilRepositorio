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

        public int Inserir(Cliente cliente)
        {
            var existe = repositorioCliente.BuscaQualquerParametro(x => x.CNPJ == cliente.CNPJ);
            if (existe == null)
            {
                cliente.DataInclusao = DateTime.Now;
                return repositorioCliente.Inserir(cliente);
            }
            else
            {
                return -1;
            }
        }

        public Cliente BuscaCliente(int Id)
        {
            if (Id > 0)
            {
                Cliente cliente = repositorioCliente.PesquisarPorId(Id);
                if (cliente != null)
                {
                    cliente.ColcarMascara();
                }
                return cliente;
            }  
            else
                return null;
        }

        public List<Cliente> ListarTodos()
        {
            List<Cliente> clientes = repositorioCliente.Listar();
            if (clientes != null)
            {
                foreach (var item in clientes)
                {
                    item.ColcarMascara();
                }
            }
            return clientes;
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
