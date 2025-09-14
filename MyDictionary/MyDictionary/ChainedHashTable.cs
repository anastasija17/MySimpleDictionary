using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class ChainedHashTable<T, R> : HashTable<T,R> 
    {
        protected SLList<HashObject<T, R>>[] array;

        public ChainedHashTable(int len) : base(len)
        {
            count = 0;
            length = len;
            array = new SLList<HashObject<T, R>>[len];
            for (int i = 0; i < len; i++)
                array[i] = new SLList<HashObject<T, R>>();
        }

       
        public void Insert(HashObject<T, R> obj)
        {
            int index = H(obj.GetKey());
            array[index].AddToHead(obj);
            count++;
        }

        
        public void Withdraw(HashObject<T, R> obj)
        {
            int index = H(obj.GetKey());
            array[index].DeleteEl(obj);
            count--;
        }

        
        public void Withdraw(T key)
        {
            HashObject<T, R> obj = Find(key);
            Withdraw(obj);
        }

     
        public HashObject<T, R> Find(T key)
        {
            int index = H(key);

            try
            {
                HashObject<T, R> obj = array[index].GetHeadEl();
                while (!obj.IsEqualKey(key))
                {
                    obj = array[index].GetNextEl(obj);
                }
                return obj;
            }
            catch (InvalidOperationException)
            {
                return null; 
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write($"Bucket {i}:  ");
                bool first = true;
                try
                {
                    var cur = array[i].GetHeadEl();
                    while (true)
                    {
                        if (!first) Console.Write(", ");
                        Console.Write($"{cur.GetKey()}: {cur.GetRecord()}"); 
                        first = false;
                        cur = array[i].GetNextEl(cur);
                    }
                }
                catch (InvalidOperationException)
                {
                    //Kraj liste
                }
                Console.WriteLine();
            }
        }

        public List<HashObject<T, R>> GetAll()
        {
            var list = new List<HashObject<T, R>>();

            for (int i = 0; i < length; i++)
            {
                try
                {
                    var obj = array[i].GetHeadEl();  
                    while (true)
                    {
                        list.Add(obj);
                        obj = array[i].GetNextEl(obj); 
                    }
                }
                catch (Exception)  
                {
                    
                }
            }

            return list;
        }

        public void PrintAllSorted()
        {
            var all = GetAll();
            var sorted = all.OrderBy(obj => obj.GetKey()).ToList();

            foreach (var obj in sorted)
            {
                Console.WriteLine($"[{obj.GetKey()}] {obj.GetRecord()}");
            }
        }

    
        public void Clear()
        {
            for (int i = 0; i < length; i++)
            {
                array[i].Clear();  
            }
            count = 0;
        }

        public int Count()
        {
            return count;
        }

    }
}
