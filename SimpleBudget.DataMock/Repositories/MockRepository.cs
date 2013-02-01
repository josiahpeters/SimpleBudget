using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.DataMock.Repositories
{
    public class MockRepository<T> : IRepository<T> where T : IIdentifiable
    {
        Dictionary<Guid, T> dataSet = new Dictionary<Guid, T>();

        public void Create(T entity)
        {
            dataSet.Add(entity.Id, entity);
        }

        public void Update(T entity)
        {
            dataSet[entity.Id] = entity;
        }

        public void Delete(Guid Id)
        {
            dataSet.Remove(Id);
        }

        public T Get(Guid Id)
        {
            if (dataSet.ContainsKey(Id))
                return dataSet[Id];
            else
                return default(T);
        }
    }
}
