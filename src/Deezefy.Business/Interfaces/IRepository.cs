﻿using Deezefy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Deezefy.Business.Interfaces
{
    public interface IRepository <T> : IDisposable where T: Entity
    {
        Task<ICollection<T>> ObterTodos();
        Task<ICollection<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task Adicionar(T entity);
        Task Atualizar(T entity);
    }
}
