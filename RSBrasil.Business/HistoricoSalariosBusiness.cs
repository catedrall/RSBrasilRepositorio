using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;

namespace RSBrasil.Business
{
    public class HistoricoSalariosBusiness
    {
        private IRepositorioBase<HistoricoSalarios> repositorioSalarios = new Repositorio<HistoricoSalarios>();

        public HistoricoSalarios Inserir(HistoricoSalarios historicoDeSalario)
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

        public HistoricoSalarios PesquisarPorId(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    HistoricoSalarios falta = repositorioSalarios.PesquisarPorId(Id);
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

        public List<HistoricoSalarios> ListarTodosPorId(int IdHistoricoSalario)
        {
            try
            {
                List<HistoricoSalarios> salarios = repositorioSalarios.BuscaTodosQualquerParametro(x => x.Id == IdHistoricoSalario);
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
                HistoricoSalarios historicosalarios = repositorioSalarios.PesquisarPorId(Id);
                repositorioSalarios.Excluir(historicosalarios);
            }
        }

        public void EditarFalta(HistoricoSalarios historicosalarios)
        {
            if (historicosalarios != null)
            {
                HistoricoSalarios local = repositorioSalarios.PesquisarPorId(historicosalarios.Id);

                local.Salario = historicosalarios.Salario;
                local.DataPagamento = historicosalarios.DataPagamento;
                local.IdFuncionario = historicosalarios.IdFuncionario;
                repositorioSalarios.Atualizar(local);
            }
        }
    }
}
