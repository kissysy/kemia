using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;//regexhez kell (otodik feladat)

namespace kemia
{
    class Megoldas
    {
        //szükséges variables deklarálása
        private string[] adatok = File.ReadAllLines("felfedezesek.csv", Encoding.Default);
        private string[,] splitelt;
        private string beadotvegyjel;
        //-------------------------------------

        public void szettordeles()
        {
            splitelt = new string[adatok.Length, 5];
            for (int i = 1; i < adatok.Length; i++)
            {
                string[] split = adatok[i].Split(';');
                splitelt[i - 1, 0] = split[0];
                splitelt[i - 1, 1] = split[1];
                splitelt[i - 1, 2] = split[2];
                splitelt[i - 1, 3] = split[3];
                splitelt[i - 1, 4] = split[4];
            }
            harmadikfeladat();
        }
        public void harmadikfeladat()
        {
            Console.WriteLine("3.feladat : Elemek száma : {0}", adatok.Length - 1);
            negyedikfeldat();
        }

        public void negyedikfeldat()
        {
            int db = 0;
            for (int i = 0; i < adatok.Length - 1; i++)
            {
                if (splitelt[i, 0] == "Ókor")
                    db++;
            }
            Console.WriteLine("4.feladat : Felfedezések száma az ókorban : {0}", db);
            otodikfeladat();
        }
        public void otodikfeladat()
        {
            bool jo = false;
            while (jo == false)
            {
                Console.Write("5.feladat:Kérek egy vegyjelet:");
                string vegyjel = Console.ReadLine();
                if (vegyjel.Length < 3 && vegyjel.Length > 0)
                {
                    bool nezes = Regex.IsMatch(vegyjel, "^[a-zA-Z0-9. -_?]*$");
                    if (nezes == true)
                    {
                        beadotvegyjel = vegyjel;
                        jo = true;
                    }
                }
            }
            //-----------------------
            hatodikfeladat();
        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            Megoldas feladatok = new Megoldas();
            feladatok.szettordeles();


            Console.ReadLine();
        }
    }
}
