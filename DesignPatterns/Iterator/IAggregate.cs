using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
        List<T> GetAll();
        void AddItem(T item);
    }

    
}
