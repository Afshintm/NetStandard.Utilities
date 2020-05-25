using System.Collections;
using System.Collections.Generic;

namespace NetStandard.Utils.Iterators
{
    public class AnotherCollection<T>: IList<T>
    {
        List<T> _data = new List<T>();
        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if(item!=null)
                _data.Add(item);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _data.CopyTo(array,arrayIndex);
        }

        public bool Remove(T item)
        {
            return _data.Remove(item);
        }

        public int Count=> _data.Count;

        public bool IsReadOnly => false;
        public int IndexOf(T item)
        {
            return _data.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _data.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            _data.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _data[index];
            set => _data[index]= value;
        }
    }
}