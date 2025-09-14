using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class HashTable<T, R>
    {
        protected int length;
        protected int count;

        public HashTable(int size)
        {
            length = size;
            count = 0;
        }

        protected int F(int key)
        {
            const uint A = 2654435761; 
            return (int)((A * (uint)key) % (uint)length);
        }

        protected int F(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            ulong hash = 5381;
            foreach (char c in s)
            {
                hash = ((hash << 5) + hash) + c; 
            }

            return (int)(hash % (ulong)length);
        }

        protected int F(double d)
        {
            long bits = BitConverter.DoubleToInt64Bits(d);
            long mixed = bits ^ (bits >> 32); 
            return F((int)mixed);
        }

        protected int H(T key)
        {
            if (key is int i) return F(i);
            if (key is string s) return F(s);
            if (key is double d) return F(d);

            return (key.GetHashCode() & 0x7FFFFFFF) % length;
        }

        public int GetLength()
        {
            return length;
        }

        public double GetLoadFactor()
        {
            return (double)count / length;
        }
    }
}

