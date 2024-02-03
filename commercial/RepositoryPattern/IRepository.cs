using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commercial.RepositoryPattern
{
    public interface IRepository<T>
    {
        T GetByEmail(string email);
    }
}