using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class TipoDocumentosBusiness
    {
        private IRepositorioBase<TipoDocumentos> repositorioTipoDeDocumentos = new Repositorio<TipoDocumentos>();

        public TipoDocumentos Inserir(TipoDocumentos tipoDeDocumentos)
        {
            try
            {
                tipoDeDocumentos.DataInclusao = DateTime.Now;
                return repositorioTipoDeDocumentos.Inserir(tipoDeDocumentos);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TipoDocumentos BuscaDocumento(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    TipoDocumentos tipoDeDocumentos = repositorioTipoDeDocumentos.PesquisarPorId(Id);
                    return tipoDeDocumentos;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }

        public List<TipoDocumentos> ListarTodos()
        {
            try
            {
                List<TipoDocumentos> tipoDeDocumentos = repositorioTipoDeDocumentos.Listar();
                return tipoDeDocumentos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ExcluirTipoDocumento(int Id)
        {
            if (Id > 0)
            {
                TipoDocumentos tipoDeDocumentos = repositorioTipoDeDocumentos.PesquisarPorId(Id);
                repositorioTipoDeDocumentos.Excluir(tipoDeDocumentos);
            }
        }

        public void EditarDocumento(TipoDocumentosDTO documento)
        {
            if (documento != null)
            {
                TipoDocumentos local = repositorioTipoDeDocumentos.PesquisarPorId(documento.Id);
                local.Descricao = documento.Descricao;
                local.DataAlteracao = DateTime.Now;
                repositorioTipoDeDocumentos.Atualizar(local);
            }
        }
    }
}
