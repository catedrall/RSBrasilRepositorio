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
        private IRepositorioBase<HistoricoFalta> repositorioHistoricoFaltas = new Repositorio<HistoricoFalta>();

        public HistoricoFalta Inserir(HistoricoFalta HistoricoDeFalta)
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

        public HistoricoFalta BuscaFalta(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    HistoricoFalta falta = repositorioHistoricoFaltas.PesquisarPorId(Id);
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

        public List<HistoricoFalta> ListarTodosPorId(int IdFuncionario)
        {
            try
            {
                List<HistoricoFalta> faltas = repositorioHistoricoFaltas.BuscaTodosQualquerParametro(x => x.IdFuncionario == IdFuncionario);
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
                HistoricoFalta HistoricoDeFalta = repositorioHistoricoFaltas.PesquisarPorId(Id);
                repositorioHistoricoFaltas.Excluir(HistoricoDeFalta);
            }
        }

        public void EditarFalta(HistoricoFaltaDTO historicoDeFalta)
        {
            if (historicoDeFalta != null)
            {
                HistoricoFalta local = repositorioHistoricoFaltas.PesquisarPorId(historicoDeFalta.Id);
                local.DataFalta = historicoDeFalta.DataFalta;
                local.IdCliente = historicoDeFalta.IdCliente.Value;
                repositorioHistoricoFaltas.Atualizar(local);
            }
        }
    }
}
