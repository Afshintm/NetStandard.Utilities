using System;
using System.Collections;
using System.Collections.Generic;

namespace NetStandard.Utils.Iterators
{
    public class Item{
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString(){
            return Name;
        }
    }
    public class SimpleCollection : IEnumerator<Item>, IEnumerable<Item>
    {
        private int _index = -1; 
        private List<Item> _items = new List<Item>
        {
            new Item{Id=0,Name="Item 0"},
            new Item{Id=1,Name="Item 1"},
            new Item{Id=2,Name="Item 2"}
        };
        
        public Item this[int index]
        {
            get{
                return _items[index];
            }
            set{ 
                _items.Insert(index,value);
            }
        }
        public Item Current  { 
            get
            {
                try{
                    return _items[_index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current {get{return Current;} }

        public void Dispose()
        {
            _items = null;
        }

        public bool MoveNext()
        {
            //move to next item and return false as soon as we pass the number of items 
            _index++ ;
            return  (_index < _items.Count);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<Item> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}