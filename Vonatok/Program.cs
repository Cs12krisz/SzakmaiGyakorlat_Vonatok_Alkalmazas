



using System.Text.Json;

namespace Vonatok
{
    internal class Program
    {
        public static List<Varakozas> varakozasok = new List<Varakozas>();
        public static List<Varakozas> varakozasListaJson = new List<Varakozas>();

        static void Main(string[] args)
        {
            BeolvasJson();
            Beolvas();
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
        }

        public static void Beolvas()
        {
            StreamReader streamReader = new StreamReader("varakozas.txt");
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                Varakozas varakozas = new Varakozas(streamReader.ReadLine());
                varakozasok.Add(varakozas);
            }
            streamReader.Close();
        }

        public static void Feladat5()
        {
            string erkező = "Esztergom";
            var megTalaltAllomas = varakozasok.FirstOrDefault(v => v.VakozikE(erkező, "Összes"));
            Console.WriteLine($"{megTalaltAllomas.Allomas} állomáson az összes vonat vár az Esztergomból érkező vonatokra.");
        }

        public static void Feladat4()
        {
            var leggosszabbVarakozas = varakozasok.MaxBy(v => v.VarakozasIdo);
            Console.WriteLine($"A leghosszabb várakozás: {leggosszabbVarakozas.VarakozasIdo} perc");
            var erintettAllomasok = varakozasok.Where(v => v.VarakozasIdo == leggosszabbVarakozas.VarakozasIdo).Select(v => v.Allomas).ToArray();
            Console.Write("Az érintett állomás(ok): ");
            for (int i = 0; i < erintettAllomasok.Count(); i++)
            {
                if (i == erintettAllomasok.Count() - 1)
                {
                    Console.Write(erintettAllomasok[i]);
                }
                else
                {
                    Console.Write(erintettAllomasok[i] + ",");
                }

            }
            Console.WriteLine();
        }

        public static void BeolvasJson()
        {
            string json = File.ReadAllText("varakozas.json");
            varakozasListaJson = JsonSerializer.Deserialize<List<Varakozas>>(json);
        }

        public static void Feladat3()
        {
            Console.Write("Hány percnél hosszabb várakozást keressek? ");
            int varakozas = int.Parse(Console.ReadLine());
            var varakozasnalHosszabbak = varakozasok.Where(v => v.VarakozasIdo > varakozas);
            Console.WriteLine($"{varakozas} percnél hosszabb várakozások száma: {varakozasnalHosszabbak.Count()}");
        }

        public static void Feladat2()
        {
            Console.Write("Kérem, adjon meg egy állomást: ");
            string allomas = Console.ReadLine();
            var allomasok = varakozasok.Where(v => v.Allomas == allomas).ToArray();
            if (allomasok.Count() == 0)
            {
                Console.WriteLine("Hiányzó adat.");
            }
            else
            {
                Console.WriteLine($"A vonal száma: {allomasok[0].Vonal}");
            }

        }

        public static void Feladat1()
        {
            Console.Write("Kérem adja meg egy vonalszámot: ");
            string vonalSzam = Console.ReadLine();
            var obj = varakozasok.Where(v => v.Vonal == vonalSzam);
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
    }
}
