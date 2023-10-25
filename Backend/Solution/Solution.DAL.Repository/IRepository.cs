﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> AsQueryable();
        IEnumerable<T> Search(Expression<Func<T,bool>>predicado);
        T GetOne(Expression<Func<T, bool>> predicado);
        T GetOneById(int id);
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        void Commit();
        void AddRange(IEnumerable<T> t);
        void UpdateRange(IEnumerable<T> t);
        void RemoveRange(IEnumerable<T> t);
    }
}
