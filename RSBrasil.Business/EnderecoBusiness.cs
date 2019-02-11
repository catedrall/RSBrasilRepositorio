using RSBrasil.Data;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class EnderecoBusiness
    {
        private IRepositorioBase<Enderecos> repositorioCliente = new Repositorio<Enderecos>();

        public Enderecos Inserir(Enderecos endereco)
        {
            //var existe = repositorioCliente.BuscaQualquerParametro(x => x.CNPJ == cliente.CNPJ);
            endereco.DataInclusao = DateTime.Now;
            return repositorioCliente.Inserir(endereco);

            /*if (existe == null)
            {
                endereco.DataInclusao = DateTime.Now;
                return repositorioCliente.Inserir(endereco);
            }
            else
            {
                return null;
            }*/
        }

        public Enderecos BuscaCliente(int Id)
        {
            if (Id > 0)
            {
                Enderecos endereco = repositorioCliente.PesquisarPorId(Id);
                /*if (endereco != null)
                {
                    endereco.ColcarMascara();
                }*/
                return endereco;
            }
            else
                return null;
        }

        public List<Enderecos> ListarTodos()
        {
            List<Enderecos> clientes = repositorioCliente.Listar();
            if (clientes != null)
            {
                /*foreach (var item in clientes)
                {
                    item.ColcarMascara();
                }*/
            }
            return clientes;
        }

        public void ExcluirCliente(int Id)
        {
            if (Id > 0)
            {
                Enderecos cliente = repositorioCliente.PesquisarPorId(Id);
                repositorioCliente.Excluir(cliente);
            }
        }

        /*public void EditarCliente(ClienteDTO cliente)
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
        }*/
    }
}
