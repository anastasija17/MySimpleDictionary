using System;
using System.Diagnostics;

namespace MyDictionary
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mojRecnik = new MyDictionary<int, Student>(10);

            int brojStudenata = 10;
            var studenti = new Student[brojStudenata];

            for (int i = 0; i < brojStudenata; i++)
            {
                studenti[i] = new Student(i, $"Ime{i}", $"Prezime{i}", 8.50);
            }

            //Dodavanje elemenata
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < brojStudenata; i++)
            {
                mojRecnik.Add(studenti[i].Index, studenti[i]);
            }
            sw.Stop();
            Console.WriteLine($"Dodavanje {brojStudenata} studenata: {sw.Elapsed.TotalMilliseconds:F2} ms");

            sw.Restart();
            mojRecnik.PrintAllSorted();
            sw.Stop();
            Console.WriteLine($"Prikaz svih studenata: {sw.Elapsed.TotalMilliseconds:F4} ms");

            // Pronalaženje po ključu
            int testIndeks = brojStudenata / 2;
            sw.Restart();
            var nadjen = mojRecnik.FindByKey(testIndeks);
            sw.Stop();
            Console.WriteLine($"Pronalaženje studenta sa indeksom {testIndeks}: {sw.Elapsed.TotalMilliseconds:F4} ms");
            if (nadjen != null)
                Console.WriteLine($"Pronadjen student: {nadjen}");

            // Pronalaženje po vrednosti
            sw.Restart();
            var nadjenPoVrednosti = mojRecnik.FindByValue(studenti[brojStudenata / 3]);
            sw.Stop();
            Console.WriteLine($"Pronalaženje po vrednosti (Student {studenti[brojStudenata / 3].Ime} {studenti[brojStudenata / 3].Prezime}): {sw.Elapsed.TotalMilliseconds:F4} ms");
            if (nadjenPoVrednosti != null)
                Console.WriteLine($"Pronadjen student sa indeksom: {nadjenPoVrednosti}");

            // Brisanje jednog elementa
            sw.Restart();
            mojRecnik.Remove(testIndeks);
            sw.Stop();
            Console.WriteLine($"Brisanje jednog studenta: {sw.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"Broj studenata posle brisanja: {mojRecnik.Count()}");


            // Brisanje celog rečnika
            sw.Restart();
            mojRecnik.Clear();
            sw.Stop();
            Console.WriteLine($"Brisanje celog rečnika: {sw.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"Broj studenata nakon brisanja: {mojRecnik.Count()}");
        }
    }
  
}
