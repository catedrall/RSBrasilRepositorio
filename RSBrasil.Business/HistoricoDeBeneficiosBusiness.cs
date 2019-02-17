using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;

namespace RSBrasil.Business
{
    public class HistoricoDeBeneficiosBusiness
    {
        private IRepositorioBase<HistoricoBeneficios> repositorioBeneficios = new Repositorio<HistoricoBeneficios>();

        public HistoricoBeneficios Inserir(HistoricoBeneficios HistoricoDeBeneficios)
        {
            HistoricoDeBeneficios.DataInclusao = DateTime.Now;

            try
            {
                return repositorioBeneficios.Inserir(HistoricoDeBeneficios);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HistoricoBeneficios BuscaFalta(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    HistoricoBeneficios falta = repositorioBeneficios.PesquisarPorId(Id);
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

        public List<HistoricoBeneficios> ListarTodosPorId(int IdFuncionario)
        {
            try
            {
                List<HistoricoBeneficios> beneficios = repositorioBeneficios.BuscaTodosQualquerParametro(x => x.IdFuncionario == IdFuncionario);
                return beneficios;
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
                HistoricoBeneficios HistoricoBeneficios = repositorioBeneficios.PesquisarPorId(Id);
                repositorioBeneficios.Excluir(HistoricoBeneficios);
            }
        }

        public void EditarFalta(HistoricoBeneficios historicoDeBenficios)
        {
            if (historicoDeBenficios != null)
            {
                HistoricoBeneficios local = repositorioBeneficios.PesquisarPorId(historicoDeBenficios.Id);

                local.IdTipoBeneficios = historicoDeBenficios.IdTipoBeneficios;
                local.DataPagamento = historicoDeBenficios.DataPagamento;
                local.IdFuncionario = historicoDeBenficios.IdFuncionario;
                repositorioBeneficios.Atualizar(local);
            }
        }
    }
}
