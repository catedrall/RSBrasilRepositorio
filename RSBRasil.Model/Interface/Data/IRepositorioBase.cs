﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RSBrasil.Model.Interface.Data
{
    public interface IRepositorioBase<T> where T : class
    {
        List<T> Listar();
        T PesquisarPorId(long id);
        T BuscaQualquerParametro(Expression<Func<T, bool>> predicate);
        int Inserir(T entity);
        void InserirVarios(List<T> entities);
        void Atualizar(T entity);
        void AtualizarVarios(List<T> entities);
        void Excluir(T entity);
        void ExcluirVarios(List<T> entities);
    }
}