using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class TipoBeneficiosBusiness
    {
        private IRepositorioBase<TipoBeneficios> repositorioTipoDeBeneficios = new Repositorio<TipoBeneficios>();

        public TipoBeneficios Inserir(TipoBeneficios tipoBeneficios)
        {
            try
            {
                tipoBeneficios.DataInclusao = DateTime.Now;
                return repositorioTipoDeBeneficios.Inserir(tipoBeneficios);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TipoBeneficios BuscaBeneficio(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    TipoBeneficios tipoBeneficio = repositorioTipoDeBeneficios.PesquisarPorId(Id);
                    return tipoBeneficio;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }

        public List<TipoBeneficios> ListarTodos()
        {
            try
            {
                List<TipoBeneficios> tipoDeBeneficios = repositorioTipoDeBeneficios.Listar();
                return tipoDeBeneficios;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ExcluirTipoBeneficios(int Id)
        {
            if (Id > 0)
            {
                TipoBeneficios tipoDeBeneficios = repositorioTipoDeBeneficios.PesquisarPorId(Id);
                repositorioTipoDeBeneficios.Excluir(tipoDeBeneficios);
            }
        }

        public void EditarTipoBeneficio(TipoBeneficiosDTO beneficio)
        {
            if (beneficio != null)
            {
                TipoBeneficios local = repositorioTipoDeBeneficios.PesquisarPorId(beneficio.Id);
                local.Descricao = beneficio.Descricao;
                local.DataAlteracao = DateTime.Now;
                repositorioTipoDeBeneficios.Atualizar(local);
            }
        }
    }
}
