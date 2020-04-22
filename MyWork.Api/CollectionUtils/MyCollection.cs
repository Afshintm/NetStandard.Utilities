#nullable enable
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyWork.Api.CollectionUtils
{
    public class MyCollection:IEnumerable, IEnumerator
    {
        private int[] data = {1, 2, 3};
        private int index = -1;
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            return index<data.Length;
        }

        public void Reset()
        {
            index = -1;
        }

        public object? Current => data[++index];
    }
    
    public class Person{
    
        public string Name{get; private set;}
        private int Age{get; set;}
    
        public Person(string name, int age){
            Name = name;
            Age = age;
        }
    }

    public class Employees: IEnumerable<Person>
    {
        private Person[] _data = new[] {new Person("Afshin",45) };
        public IEnumerator<Person> GetEnumerator()
        {
            return (IEnumerator<Person>) _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}