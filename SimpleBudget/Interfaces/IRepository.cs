using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public interface IRepository<T> where T : IIdentifiable
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid Id);
        T Get(Guid Id);
    }
}
