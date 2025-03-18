using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListHomework
{
    internal class MyList<T> : IEnumerable<T>
    {
        private int _count;
        private int _capacity;
        private T[] values;

        public MyList()
        {
            _count = 0;
            _capacity = 0;
            values = new T[_capacity];
        }
        public MyList(int copacity)
        {
            _count = 0;
            _capacity = copacity;
            values = new T[_capacity];
        }
        public MyList(T[] array)
        {
            _count = array.Length;
            _capacity = array.Length;
            values = new T[_capacity];
        }
        public int Count { 
            get {
                return _count;
            } 
            private set {
                _count = value;
            }
        }
        public int Capacity
        {
            get {
                return _capacity;
            }
            private set {
                _capacity = value;
            }
        }
        public T this[int flag]
        {
            get
            {
                return values[flag];
            }
            set
            {
                values[flag] = value;
            }
        }
        public void Add(T value)
        {
            Count++;
            if(Capacity == 0)
            {
                Capacity = 4;
                values = new T[_capacity];
            }
            if (Capacity < Count)
            {
                Capacity *= 2;
                T[] tmp = new T[values.Length];
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] = values[i];
                }

                values = new T[Capacity];
                for (int i = 0; i < tmp.Length; i++)
                {
                    values[i] = tmp[i];
                }
            }
            values[Count - 1] = value;
        }
        public void Remove(T value) 
        {
            for (int i = 0; i < values.Length; i++)
            {
                if(values[i] != null && values[i]!.Equals(value))
                {
                    for(int j = i; j < values.Length - 1; j++)
                    {
                        values[j] = values[j + 1];
                    }
                    Count--;
                    break;
                }
            }

        }
        public void RemoveAt(int index)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (i == index)
                {
                    for (int j = i; j < values.Length - 1; j++)
                    {
                        values[j] = values[j + 1];
                    }
                    Count--;
                    break;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(values);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
