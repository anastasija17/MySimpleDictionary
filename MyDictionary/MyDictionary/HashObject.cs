using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class HashObject<T, R>
    {
        public T key;
        public R record;

        public HashObject()
        {
            key = default(T)!;   
            record = default(R)!;
        }

        public HashObject(T k)
        {
            key = k;
            record = default(R)!;
        }

        public HashObject(T k, R r)
        {
            key = k;
            record = r;
        }

        public T GetKey()
        {
            return key;
        }

        public R GetRecord()
        {
            return record;
        }

        public void SetRecord(R r)
        {
            record = r;
        }

        public bool IsEqualKey(T k)
        {
            return EqualityComparer<T>.Default.Equals(key, k);
        }

        public bool Equals(HashObject<T, R> other)
        {
            if (other == null)
                return false;
            return EqualityComparer<R>.Default.Equals(record, other.record);
        }

        public void DeleteRecord()
        {
            record = default(R);
        }

        public void Print()
        {
            Console.WriteLine($"{key} | {record}");
        }

        public override string ToString()
        {
            return $"{key} | {record}";
        }

    }
}

