using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;

namespace RSBrasil.Business
{
    public class HistoricoDeSalariosBusiness
    {
        private IRepositorioBase<HistoricoDeSalarios> repositorioSalarios = new Repositorio<HistoricoDeSalarios>();

        public HistoricoDeSalarios Inserir(HistoricoDeSalarios historicoDeSalario)
        {
            historicoDeSalario.DataInclusao = DateTime.Now;

            try
            {
                return repositorioSalarios.Inserir(historicoDeSalario);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HistoricoDeSalarios PesquisarPorId(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    HistoricoDeSalarios falta = repositorioSalarios.PesquisarPorId(Id);
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

        public List<HistoricoDeSalarios> ListarTodosPorId(int IdHistoricoSalario)
        {
            try
            {
                List<HistoricoDeSalarios> salarios = repositorioSalarios.BuscaTodosQualquerParametro(x => x.Id == IdHistoricoSalario);
                return salarios;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ExcluirHistoricoSalario(int Id)
        {
            if (Id > 0)
            {
                HistoricoDeSalarios historicosalarios = repositorioSalarios.PesquisarPorId(Id);
                repositorioSalarios.Excluir(historicosalarios);
            }
        }

        public void EditarFalta(HistoricoDeSalarios historicosalarios)
        {
            if (historicosalarios != null)
            {
                HistoricoDeSalarios local = repositorioSalarios.PesquisarPorId(historicosalarios.Id);

                local.Salario = historicosalarios.Salario;
                local.DataPagamento = historicosalarios.DataPagamento;
                local.IdFuncionario = historicosalarios.IdFuncionario;
                repositorioSalarios.Atualizar(local);
            }
        }
    }
}
