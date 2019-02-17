using RSBrasil.Data;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class TipoDeDocumentosBusiness
    {
        private IRepositorioBase<TipoDeDocumentos> repositorioTipoDeDocumentos = new Repositorio<TipoDeDocumentos>();

        public TipoDeDocumentos Inserir(TipoDeDocumentos tipoDeDocumentos)
        {
            //var existe = repositorioUniforme.BuscaQualquerParametro(x => x.CNPJ == uniforme.CNPJ);
            //if (existe == null)
            //{
                tipoDeDocumentos.DataInclusao = DateTime.Now;
                return repositorioTipoDeDocumentos.Inserir(tipoDeDocumentos);
            //}
            //else
            //{
            //    return null;
            //}
        }

        public TipoDeDocumentos BuscaDocumento(int Id)
        {
            if (Id > 0)
            {
                TipoDeDocumentos tipoDeDocumentos = repositorioTipoDeDocumentos.PesquisarPorId(Id);
                if (tipoDeDocumentos != null)
                {
                    //uniforme.ColcarMascara();
                }
                return tipoDeDocumentos;
            }
            else
                return null;
        }

        public List<TipoDeDocumentos> ListarTodos()
        {
            List<TipoDeDocumentos> tipoDeDocumentos = repositorioTipoDeDocumentos.Listar();
            if (tipoDeDocumentos != null)
            {
                foreach (var item in tipoDeDocumentos)
                {
                    //item.ColcarMascara();
                }
            }
            return tipoDeDocumentos;
        }

        public void ExcluirTipoDocumento(int Id)
        {
            if (Id > 0)
            {
                TipoDeDocumentos tipoDeDocumentos = repositorioTipoDeDocumentos.PesquisarPorId(Id);
                repositorioTipoDeDocumentos.Excluir(tipoDeDocumentos);
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
