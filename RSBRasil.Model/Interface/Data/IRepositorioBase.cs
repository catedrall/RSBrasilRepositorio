using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Model.Interface.Data
{
    public interface IRepositorioBase<T> where T : class
    {
        List<T> Listar();
        T PesquisarPorId(long id);
        void Inserir(T entity);
        void InserirVarios(List<T> entities);
        void Atualizar(T entity);
        void AtualizarVarios(List<T> entities);
        void Excluir(T entity);
        void ExcluirVarios(List<T> entities);
    }
}
