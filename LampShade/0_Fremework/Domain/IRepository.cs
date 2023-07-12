﻿using System.Linq.Expressions;

namespace _0_Fremework.Domain
{
    public interface IRepository<TKey, T> where T : class
    {
        T Get(TKey id);
        List<T> Get();

        bool Exists(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Savechangs();

    }
}
