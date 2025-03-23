using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListHomework
{
    internal class MyEnumerator<T> : IEnumerator<T>
    {
        T[] values;
        int position = -1;
        public MyEnumerator(T[] values)
        {
            this.values = values;
        }
        public T Current
        {
            get
            {
                if (position == -1 || position >= values.Length)
                    throw new ArgumentException();
                return values[position];
            }
        }
        object IEnumerator.Current => Current;
        public bool MoveNext()
        {
            if (position < values.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
}
