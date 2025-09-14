using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class MyDictionary<TKey, TValue> : ChainedHashTable<TKey, TValue>
    {
        public MyDictionary(int size) : base(size) { }

     
        public void Add(TKey key, TValue value)
        {
            var obj = new HashObject<TKey, TValue>(key, value);
            Insert(obj);
        }

        public void Remove(TKey key)
        {
             Withdraw(key);
        }


        public TValue FindByKey(TKey key)
        {
            var obj = Find(key);
            if (obj != null)
                return obj.GetRecord();
            throw new KeyNotFoundException($"Kljuc '{key}' nije pronadjen.");
        }

        public TKey FindByValue(TValue value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    var obj = array[i].GetHeadEl();
                    while (true)
                    {
                        if (EqualityComparer<TValue>.Default.Equals(obj.GetRecord(), value))
                            return obj.GetKey();
                        obj = array[i].GetNextEl(obj);
                    }
                }
                catch (InvalidOperationException) { }
            }
            throw new KeyNotFoundException($"Vrednost '{value}' nije pronadjena.");
        }

        public List<TKey> Keys()
        {
            var keys = new List<TKey>();
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    var obj = array[i].GetHeadEl();
                    while (true)
                    {
                        keys.Add(obj.GetKey());
                        obj = array[i].GetNextEl(obj);
                    }
                }
                catch (InvalidOperationException) { }
            }
            return keys;
        }

        public List<TValue> Values()
        {
            var values = new List<TValue>();
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    var obj = array[i].GetHeadEl();
                    while (true)
                    {
                        values.Add(obj.GetRecord());
                        obj = array[i].GetNextEl(obj);
                    }
                }
                catch (InvalidOperationException) { }
            }
            return values;
        }

        public int Count()
        {
            return base.Count();
        }

        public void PrintAll()
        {
            Console.WriteLine("{");
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    var obj = array[i].GetHeadEl();
                    while (true)
                    {
                        Console.WriteLine($"  [{obj.GetKey()}] = {obj.GetRecord()}");
                        obj = array[i].GetNextEl(obj);
                    }
                }
                catch (InvalidOperationException) { }
            }
            Console.WriteLine("}");
        }
        public new void Clear()
        {
            base.Clear(); 
        }

    }
}
