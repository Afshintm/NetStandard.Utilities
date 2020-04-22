
using System.Collections;
using System.Collections.Generic;

namespace NetStandard.Utils.DataStructures
{
    public class Node<T>
    {
        public Node(T t)
        {
            Data = t;
            Next = null;
            Prev = null;
        }

        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
    }

    public class SimpleLinkedList<T>: IEnumerable<T>
    {
        internal Node<T> _head;
        private int _count;

        public SimpleLinkedList(T item) {
            var node = new Node<T>(item);
            _head = node;
            _count++;
        }

        public int Count => _count;

        public SimpleLinkedList<T> InsertFirst(T item)
        {
            var node = new Node<T>(item);
            node.Next = _head;
            if (_head != null)
                _head.Prev = node;
            _count++;
            return this;
        }

        public SimpleLinkedList<T> InsertLast(T item)
        {
            var node = new Node<T>(item);
            if (_head == null)
                _head = node;
            else
            {
                GetLastNode().Next = node;
            }
            _count++;
            return this;
        }

        private Node<T> GetLastNode()
        {
            var last = _head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            return last;
        }

        public List<T> ToList()
        {
            if (_head == null) return null;
            
            var result = new List<T>();
            var temp = _head;
            do
            {
                result.Add(temp.Data);
                temp = temp.Next;
            } while (temp != null);
            return result;
        }


        SimpleEnumerator<T> GetSimpleEnumerator()
        {
            return new SimpleEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetSimpleEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetSimpleEnumerator();
        }
    }

    public  struct SimpleEnumerator<T> : IEnumerator<T> 
    {
        private SimpleLinkedList<T> _list;
        private T _current;
        private int _index;
        private Node<T> node;

        public SimpleEnumerator(SimpleLinkedList<T> list)
        {
            _list = list;
            _current = default;
            _index = -1;
            node = _list._head;
        }
        public bool MoveNext()
        {
            ++_index;
            
            if (_list.Count == 0 || _index>=_list.Count)
                return false;
            
            _current = node.Data;
            node = node.Next;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public T Current
        {
            get { return _current; }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }
    }
    
}
