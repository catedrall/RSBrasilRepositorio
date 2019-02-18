using RSBrasil.Data;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Interface.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Business
{
    public class UniformeBusiness
    {
        private IRepositorioBase<Uniforme> repositorioUniforme = new Repositorio<Uniforme>();

        public Uniforme Inserir(Uniforme uniforme)
        {
            try
            {
                uniforme.DataInclusao = DateTime.Now;
                return repositorioUniforme.Inserir(uniforme);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Uniforme BuscaUniforme(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    Uniforme uniforme = repositorioUniforme.PesquisarPorId(Id);
                    return uniforme;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }

        public List<Uniforme> ListarTodos()
        {            
            try
            {
                List<Uniforme> uniformes = repositorioUniforme.Listar();
                return uniformes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ExcluirCliente(int Id)
        {
            if (Id > 0)
            {
                Uniforme uniforme = repositorioUniforme.PesquisarPorId(Id);
                repositorioUniforme.Excluir(uniforme);
            }
        }

        public void EditarUniforme(UniformeDTO uniforme)
        {
            if (uniforme != null)
            {
                Uniforme local = repositorioUniforme.PesquisarPorId(uniforme.Id);
                local.DataCompra = uniforme.DataCompra;
                local.Descricao = uniforme.Descricao;
                local.DataAlteracao = DateTime.Now;
                local.Duracao = uniforme.Duracao;
                repositorioUniforme.Atualizar(local);
            }
        }
    }
}
