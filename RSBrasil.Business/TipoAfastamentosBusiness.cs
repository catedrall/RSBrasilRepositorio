using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class TipoAfastamentosBusiness
    {
        private IRepositorioBase<TipoAfastamentos> repositorioTipoDeAfastamentos = new Repositorio<TipoAfastamentos>();

        public TipoAfastamentos Inserir(TipoAfastamentos tipoDeAfastamentos)
        {
            try
            {
                tipoDeAfastamentos.DataInclusao = DateTime.Now;
                return repositorioTipoDeAfastamentos.Inserir(tipoDeAfastamentos);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TipoAfastamentos BuscaTipoDeAfastamento(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    TipoAfastamentos tipoDeAfastamentos = repositorioTipoDeAfastamentos.PesquisarPorId(Id);
                    return tipoDeAfastamentos;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }

        public List<TipoAfastamentos> ListarTodos()
        {
            try
            {
                List<TipoAfastamentos> tipoDeAfastamentos = repositorioTipoDeAfastamentos.Listar();
                return tipoDeAfastamentos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ExcluirTipoAfastamento(int Id)
        {
            if (Id > 0)
            {
                TipoAfastamentos tipoDeAfastamentos = repositorioTipoDeAfastamentos.PesquisarPorId(Id);
                repositorioTipoDeAfastamentos.Excluir(tipoDeAfastamentos);
            }
        }

        public void Editarfastamento(TipoAfastamentosDTO afastamento)
        {
            if (afastamento != null)
            {
                TipoAfastamentos local = repositorioTipoDeAfastamentos.PesquisarPorId(afastamento.Id);
                local.DataCompra = afastamento.DataCompra;
                local.Descricao = afastamento.Descricao;
                local.Duracao = afastamento.Duracao;
                local.DataAlteracao = DateTime.Now;
                repositorioTipoDeAfastamentos.Atualizar(local);
            }
        }
    }
}
