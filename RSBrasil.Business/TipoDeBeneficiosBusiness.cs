using RSBrasil.Data;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class TipoDeBeneficiosBusiness
    {
        private IRepositorioBase<TipoDeBeneficios> repositorioTipoDeBeneficios = new Repositorio<TipoDeBeneficios>();

        public TipoDeBeneficios Inserir(TipoDeBeneficios tipoBeneficios)
        {
            //var existe = repositorioUniforme.BuscaQualquerParametro(x => x.CNPJ == uniforme.CNPJ);
            //if (existe == null)
            //{
                tipoBeneficios.DataInclusao = DateTime.Now;
                return repositorioTipoDeBeneficios.Inserir(tipoBeneficios);
            //}
            //else
            //{
            //    return null;
            //}
        }

        public TipoDeBeneficios BuscaBeneficio(int Id)
        {
            if (Id > 0)
            {
                TipoDeBeneficios tipoBeneficio = repositorioTipoDeBeneficios.PesquisarPorId(Id);
                if (tipoBeneficio != null)
                {
                    //uniforme.ColcarMascara();
                }
                return tipoBeneficio;
            }
            else
                return null;
        }

        public List<TipoDeBeneficios> ListarTodos()
        {
            List<TipoDeBeneficios> tipoDeBeneficios = repositorioTipoDeBeneficios.Listar();
            if (tipoDeBeneficios != null)
            {
                foreach (var item in tipoDeBeneficios)
                {
                    //item.ColcarMascara();
                }
            }
            return tipoDeBeneficios;
        }

        public void ExcluirTipoBeneficios(int Id)
        {
            if (Id > 0)
            {
                TipoDeBeneficios tipoDeBeneficios = repositorioTipoDeBeneficios.PesquisarPorId(Id);
                repositorioTipoDeBeneficios.Excluir(tipoDeBeneficios);
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
