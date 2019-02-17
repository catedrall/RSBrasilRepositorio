using RSBrasil.Data;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class TipoDeAfastamentosBusiness
    {
        private IRepositorioBase<TipoDeAfastamentos> repositorioTipoDeAfastamentos = new Repositorio<TipoDeAfastamentos>();

        public TipoDeAfastamentos Inserir(TipoDeAfastamentos tipoDeAfastamentos)
        {
            //var existe = repositorioUniforme.BuscaQualquerParametro(x => x.CNPJ == uniforme.CNPJ);
            //if (existe == null)
            //{
                tipoDeAfastamentos.DataInclusao = DateTime.Now;
                return repositorioTipoDeAfastamentos.Inserir(tipoDeAfastamentos);
            //}
            //else
            //{
            //    return null;
            //}
        }

        public TipoDeAfastamentos BuscaTipoDeAfastamento(int Id)
        {
            if (Id > 0)
            {
                TipoDeAfastamentos tipoDeAfastamentos = repositorioTipoDeAfastamentos.PesquisarPorId(Id);
                if (tipoDeAfastamentos != null)
                {
                    //uniforme.ColcarMascara();
                }
                return tipoDeAfastamentos;
            }
            else
                return null;
        }

        public List<TipoDeAfastamentos> ListarTodos()
        {
            List<TipoDeAfastamentos> tipoDeAfastamentos = repositorioTipoDeAfastamentos.Listar();
            if (tipoDeAfastamentos != null)
            {
                foreach (var item in tipoDeAfastamentos)
                {
                    //item.ColcarMascara();
                }
            }
            return tipoDeAfastamentos;
        }

        public void ExcluirTipoAfastamento(int Id)
        {
            if (Id > 0)
            {
                TipoDeAfastamentos tipoDeAfastamentos = repositorioTipoDeAfastamentos.PesquisarPorId(Id);
                repositorioTipoDeAfastamentos.Excluir(tipoDeAfastamentos);
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
