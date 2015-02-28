using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class ConcreteAggregate<T> : IAggregate<T>
    {
        private IIterator<T> iterator;

        public ConcreteAggregate()
        {
            (this as IAggregate<T>).CreateIterator();  //create the iterator
        }

        public IIterator<T> CreateIterator()
        {
            //create iterator if not already done
            if (iterator == null)
                iterator = new ConcreteIterator<T>(this);
            return iterator;
        }

        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            list.Add(iterator.First());
            while (!iterator.IsDone())
            {
                list.Add(iterator.Next());
            }
            return list;
        }

        public void AddItem(T item)
        {
            iterator.AddItem(item);
        }
    }
}
