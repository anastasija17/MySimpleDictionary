using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class SLList<T>
    {
        private Node<T> head;

        public SLList()
        {
            head = null;
        }

        public void AddToHead(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
        }

        public void DeleteEl(T data)
        {
            Node<T> current = head;
            Node<T> prev = null;

            while (current != null)
            {
                if (current.Data!.Equals(data))
                {
                    if (prev == null)
                        head = current.Next;
                    else
                        prev.Next = current.Next;
                    return;
                }
                prev = current;
                current = current.Next;
            }
        }

        public T GetHeadEl()
        {
            if (head == null)
                throw new InvalidOperationException("Lista je prazna.");
            return head.Data!;
        }

        public T GetNextEl(T currentData)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.Data!.Equals(currentData))
                {
                    if (current.Next == null)
                        throw new InvalidOperationException("Kraj liste.");
                    return current.Next.Data!;
                }
                current = current.Next;
            }
            throw new InvalidOperationException("Element nije pronadjen.");
        }

       
        public void Clear()
        {
            head = null;  
        }

        public bool IsEmpty()
        {
            if (head == null)
                return true;
            else
                return false;
        }
    }


}
