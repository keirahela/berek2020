using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Berek2020
{
    internal class FoProgram
    {
        static void Main(string[] args)
        {
            List<Munkavallalo> munkavallaloLista = new List<Munkavallalo>();
            using StreamReader olvaso = new StreamReader(path: "berek2020.txt", Encoding.UTF8);
            olvaso.ReadLine();
            while (!olvaso.EndOfStream)
            {
                munkavallaloLista.Add(new Munkavallalo(olvaso.ReadLine()));
            }

            Console.WriteLine($"3. Feladat: Munkavállalók száma: {munkavallaloLista.Count} fő");

            var atlagBer = munkavallaloLista.Average(e => e.Ber);
            Console.WriteLine($"4. Feladat: {Math.Round((atlagBer / 1000), 1)} ezer Ft");

            Console.Write($"5. Feladat: Kérem adja meg a részleg nevét: ");
            string reszlegInput = Console.ReadLine().ToLower();
            var legmagasabbBeruMunkavallalo = munkavallaloLista
                .Where(emp => emp.Reszleg == reszlegInput)
                .OrderByDescending(emp => emp.Ber)
                .FirstOrDefault();

            if (legmagasabbBeruMunkavallalo != null)
            {
                Console.WriteLine($"6. Feladat: A megadott részleg legmagasabb bérű munkavállalója:" +
                    $"\n\tNév: {legmagasabbBeruMunkavallalo.Nev}\n\tNeme: {(legmagasabbBeruMunkavallalo.Neme ? "férfi" : "nő")}" +
                    $"\n\tBelépés Dátuma: {legmagasabbBeruMunkavallalo.BelepesEv}\n\tBér: {legmagasabbBeruMunkavallalo.Ber:000 000} Ft");
            }
            else
            {
                Console.WriteLine($"6. Feladat: A megadott részleg nem létezik a cégnél!");
            }

            var reszlegStatisztika = munkavallaloLista.GroupBy(emp => emp.Reszleg).OrderBy(csoport => csoport.Key);
            Console.WriteLine("7. Feladat: Statisztika");
            foreach (var csoport in reszlegStatisztika)
            {
                Console.WriteLine($"\t{csoport.Key} - {csoport.Count()} Munkavállaló");
            }
        }
    }
}