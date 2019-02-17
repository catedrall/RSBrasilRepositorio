using RSBrasil.Data;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class UniformeBusiness
    {
        private IRepositorioBase<Uniforme> repositorioUniforme = new Repositorio<Uniforme>();

        public Uniforme Inserir(Uniforme uniforme)
        {
            //var existe = repositorioUniforme.BuscaQualquerParametro(x => x.CNPJ == uniforme.CNPJ);
            //if (existe == null)
            //{
                uniforme.DataInclusao = DateTime.Now;
                return repositorioUniforme.Inserir(uniforme);
            //}
            //else
            //{
            //    return null;
            //}
        }

        public Uniforme BuscaCliente(int Id)
        {
            if (Id > 0)
            {
                Uniforme uniforme = repositorioUniforme.PesquisarPorId(Id);
                if (uniforme != null)
                {
                    //uniforme.ColcarMascara();
                }
                return uniforme;
            }
            else
                return null;
        }

        public List<Uniforme> ListarTodos()
        {
            List<Uniforme> clientes = repositorioUniforme.Listar();
            if (clientes != null)
            {
                foreach (var item in clientes)
                {
                    //item.ColcarMascara();
                }
            }
            return clientes;
        }

        public void ExcluirCliente(int Id)
        {
            if (Id > 0)
            {
                Uniforme uniforme = repositorioUniforme.PesquisarPorId(Id);
                repositorioUniforme.Excluir(uniforme);
            }
        }

        /*public void EditarCliente(ClienteDTO uniforme)
        {
            if (uniforme != null)
            {
                uniforme local = repositorioUniforme.PesquisarPorId(uniforme.Id);
                local.CNPJ = uniforme.CNPJ;
                local.Contato = uniforme.Contato;
                local.DataAlteracao = DateTime.Now;
                local.Email = uniforme.Email;
                local.IdContrato = uniforme.IdContrato;
                local.NomeFantasia = uniforme.NomeFantasia;
                local.RazaoSocial = uniforme.RazaoSocial;
                local.Telefone = uniforme.Telefone;
                repositorioUniforme.Atualizar(local);
            }
        }*/
    }
}
