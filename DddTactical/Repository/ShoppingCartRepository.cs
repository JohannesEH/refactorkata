using DddTactical.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DddTactical.Repository
{
    public class GenericRepo<T> : IRepository<T> where T: IEntity
    {
        private ConcurrentDictionary<Guid, T> FakeRepo = new ConcurrentDictionary<Guid, T>();

        public T Get(Guid id)
        {
            return FakeRepo[id];
        }

        public T Find(Guid id)
        {
            return FakeRepo.GetValueOrDefault(id);
        }

        public void Save(T entity)
        {
            FakeRepo.AddOrUpdate(entity.Id, entity, (i, c)=> entity);
        }
    }

    public class ShoppingCartRepository : GenericRepo<ShoppingCart>
    {
    }
}
