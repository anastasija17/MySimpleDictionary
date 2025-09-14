using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class Student
    {
        public int Index { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public double Prosek { get; set; }

        public Student(int id, string ime, string prezime, double p)
        {
            Index = id;
            Ime = ime;
            Prosek = p;
            Prezime = prezime;
        }

        public override string ToString()
        {
            return $"{Index}: {Ime} {Prezime}: {Prosek}";
        }

        
        public override bool Equals(object obj)
        {
            if (obj is Student other)
                if (Index == other.Index)
                    return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }
    }
}
