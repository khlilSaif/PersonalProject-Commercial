using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commercial.RepositoryPattern
{
    public interface IRepositoryPattern<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}