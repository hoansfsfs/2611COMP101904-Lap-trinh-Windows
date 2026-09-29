using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_ProductManager
{
    public class Repository<T> where T : IEntity
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public T FindById(string id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return items.Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return items;
        }
    }
}
