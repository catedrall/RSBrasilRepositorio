using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;

namespace RSBrasil.Business
{
    public class HistoricoFaltasBusiness
    {
        private IRepositorioBase<HistoricoDeFalta> repositorioHistoricoFaltas = new Repositorio<HistoricoDeFalta>();

        public HistoricoDeFalta Inserir(HistoricoDeFalta HistoricoDeFalta)
        {
            HistoricoDeFalta.DataInclusao = DateTime.Now;

            try
            {
                return repositorioHistoricoFaltas.Inserir(HistoricoDeFalta);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HistoricoDeFalta BuscaFalta(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    HistoricoDeFalta falta = repositorioHistoricoFaltas.PesquisarPorId(Id);
                    return falta;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }

        public List<HistoricoDeFalta> ListarTodosPorId(int IdFuncionario)
        {
            try
            {
                List<HistoricoDeFalta> faltas = repositorioHistoricoFaltas.BuscaTodosQualquerParametro(x => x.IdFuncionario == IdFuncionario);
                return faltas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ExcluirFalta(int Id)
        {
            if (Id > 0)
            {
                HistoricoDeFalta HistoricoDeFalta = repositorioHistoricoFaltas.PesquisarPorId(Id);
                repositorioHistoricoFaltas.Excluir(HistoricoDeFalta);
            }
        }

        public void EditarFalta(HistoricoDeFaltaDTO historicoDeFalta)
        {
            if (historicoDeFalta != null)
            {
                HistoricoDeFalta local = repositorioHistoricoFaltas.PesquisarPorId(historicoDeFalta.Id);
                local.DataFalta = historicoDeFalta.DataFalta;
                local.IdCliente = historicoDeFalta.IdCliente.Value;
                repositorioHistoricoFaltas.Atualizar(local);
            }
        }
    }
}
