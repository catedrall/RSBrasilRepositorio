using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class HistoricoPunicaoBusiness
    {
        private IRepositorioBase<HistoricoPunicao> repositorioHistoricoPunicao = new Repositorio<HistoricoPunicao>();

        public HistoricoPunicao Inserir(HistoricoPunicao historicoPunicao)
        {
            var existe = repositorioHistoricoPunicao.BuscaQualquerParametro(x => x.DataInclusao == historicoPunicao.DataInclusao);
            if (existe == null)
            {
                historicoPunicao.DataInclusao = DateTime.Now;
                return repositorioHistoricoPunicao.Inserir(historicoPunicao);
            }
            else
            {
                return null;
            }
        }

        public HistoricoPunicao BuscaHistoricoPunicao(int Id)
        {
            if (Id > 0)
            {
                HistoricoPunicao historicoPunicao = repositorioHistoricoPunicao.PesquisarPorId(Id);
                return historicoPunicao;
            }
            else
                return null;
        }

        public List<HistoricoPunicao> ListarTodos()
        {
            List<HistoricoPunicao> punicoes = repositorioHistoricoPunicao.Listar();
            return punicoes;
        }

        public void ExcluirPunicao(int Id)
        {
            if (Id > 0)
            {
                HistoricoPunicao historicoPunicao = repositorioHistoricoPunicao.PesquisarPorId(Id);
                repositorioHistoricoPunicao.Excluir(historicoPunicao);
            }
        }

        public void EditarPunicao(HistoricoPunicaoDTO historicoPunicao)
        {
            if (historicoPunicao != null)
            {
                HistoricoPunicao local = repositorioHistoricoPunicao.PesquisarPorId(historicoPunicao.Id);
                local.DataPunicao = historicoPunicao.DataPunicao;
                local.Descricao = historicoPunicao.Descricao;
                local.DataAlteracao = DateTime.Now;
                local.IdFuncionario = historicoPunicao.IdFuncionario;
                repositorioHistoricoPunicao.Atualizar(local);
            }
        }
    }
}
