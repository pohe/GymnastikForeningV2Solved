using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IComparable<T>
    {
        private List<T> _list;

        public GenericRepository()
        {
            _list = new List<T>();
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Remove(T item)
        {
            if (_list.Contains(item))
            {
                _list.Remove(item);
            }
        }

        public void Update(T oldItem, T newItem)
        {
            if (_list.Contains(oldItem))
            {
                int index = _list.IndexOf(oldItem);
                _list[index] = newItem;
            }
        }
        public int Count
        {
            get { return _list.Count; }
        }

        public List<T> List
        {
            get { return _list; }
        }

    }
}
