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
            _capacity = 4;
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

        public void Clear()
        {
            _count = 0;
            _capacity = 4;
            values = new T[_capacity];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (values[i]!.Equals(item))
                    return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (values[i]!.Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (_count == _capacity)
            {
                Capacity *= 2;
                T[] tmp = new T[Capacity];
                for (int i = 0; i < _count; i++)
                {
                    tmp[i] = values[i];
                }
                values = tmp;
            }

            for (int i = _count; i > index; i--)
            {
                values[i] = values[i - 1];
            }
            values[index] = item;
            _count++;
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                result[i] = values[i];
            }
            return result;
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
