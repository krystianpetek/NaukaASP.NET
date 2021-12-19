// mapowanie na inna koleckej np . GGappsDTO class
// select
// selectmany
// typ anonimowy

// dzielenie danych
// take(5);
// takelast
// takewhile
// skip

// ORDER DATA
// orderby();
// orderbydescending;
// orderbydescending().thenby(app => app.name);

// operacje na zbiorach
// datasetoperation()
//  paid app categories
// where.select.distinct();
// a.Union(b);
// a.intersect(b);
// a.Except(b);

// weryfikacja danych
// where.all(a=>a.Reviews > 20) - false

// where.any(a=>a.Reviews > 2_000_000) - true

using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string csvPath = $"C:/GITHUB/NaukaASP.NET/LINQ/googleplaystore1.csv";
            string csvPath = $"../../../googleplaystore1.csv";
            var app = LoadGoogleAps(csvPath);

            //Display(app);
            //GetData(app);
            //ProjectData(app);
            //DivideData(app);
            //OrderData(app);
            //DataSetOperation(app);
            //DataVerification(app);
            //GroupData(app);
            GroupDataOperations(app);
        }
        static void GroupDataOperations(IEnumerable<googleApp> app)
        {
            // 13.20
        }

        static void GroupData(IEnumerable<googleApp> app)
        {
            var grupyKategorii = app.GroupBy(apka => apka.Category);
            var grupaArtAndDesign = grupyKategorii.First(apka => apka.Key == Category.ART_AND_DESIGN); 
            var wynikGrupaArtAndDesign = grupaArtAndDesign.ToList(); //var wynikGrupaArtAndDesign = grupaArtAndDesign.Select(apka => apka);
            //Console.WriteLine($"Resultat dzialania grupowania po kategorii {grupaArtAndDesign.Key}");

            foreach(var grupy in grupyKategorii)
            {
                var wynik = grupy.ToList();
                Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine($"\nGrupowanie po kategorii: {grupy.Key}");
                Console.ResetColor();
                var wez5Wynikow = wynik.Take(5).ToList();
                //Display(wez5Wynikow);
            }

            var grupyKategoriaTyp = app.GroupBy(apka => new { apka.Category, apka.Type } );
            foreach(var grupy in grupyKategoriaTyp)
            {
                var apps = grupy.ToList();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Grupowanie elementow dla Kategorii: {grupy.Key.Category} TYP: {grupy.Key.Type}");
                Console.ResetColor();
                Display(apps.Take(2));
            }


            //Display(wynikGrupaArtAndDesign);


        }
        static void DataVerification(IEnumerable<googleApp> app)
        {
            var wynikOperatoraAll = app
                .Where(a => a.Category == Category.WEATHER)
                .All(a => a.Reviews > 10);
            Console.WriteLine($"{nameof(wynikOperatoraAll)} {wynikOperatoraAll}");


            var wynikOperatoraAny = app
                .Where(a => a.Category == Category.WEATHER)
                .Any(a => a.Reviews > 3_000_000);
            Console.WriteLine($"{nameof(wynikOperatoraAny)} {wynikOperatoraAny}");
        }

        static void DataSetOperation(IEnumerable<googleApp> app)
        {
            var kategoriePlatnychAplikacji = app
                .Where(x => x.Type == Type.Paid)
                .Select(x => x.Category)
                .Distinct();
            //Console.WriteLine($"Płatne aplikacje kategorie: \n{string.Join(Environment.NewLine, kategoriePlatnychAplikacji)}");

            var setA = app
                .Where(x => x.Rating > 4.7)
                .Where(x => x.Type == Type.Paid)
                .Where(x => x.Reviews > 1000);
            var setB = app
                .Where(x => x.Name.Contains("Pro"))
                .Where(x => x.Rating > 4.6)
                .Where(x => x.Reviews > 10000);

            var polaczoneSetASetB = setA.Union(setB);
            var wspolneSetAsetB = setA.Intersect(setB);
            var wylaczSetASetB = setA.Except(setB);
            var wylaczSetBSetA = setB.Except(setA);

            Console.WriteLine(nameof(wylaczSetASetB));
            Display(wylaczSetASetB);
            Console.WriteLine();
            Console.WriteLine(nameof(wylaczSetBSetA));
            Display(wylaczSetBSetA);

        }
        static void OrderData(IEnumerable<googleApp> app)
        {
            var nazwaAplikacjiNaKGame = app
                .Where(x => x.Name.StartsWith("K"))
                .Where(x => x.Category == Category.GAME);
            var sortowanaNazwaAplikacjiNaKGame = nazwaAplikacjiNaKGame.OrderBy(app => app.Rating);
            var sortowanaMalejacoNazwaAplikacjiNaKGame = nazwaAplikacjiNaKGame.OrderByDescending(app => app.Reviews);
            var kolejnyWarunekSortowanaMalejacoNazwaAplikacjiNaKGame = nazwaAplikacjiNaKGame
                .OrderByDescending(app => app.Rating)
                .ThenByDescending(app=>app.Name)
                .ThenByDescending(app=>app.Reviews);

            Console.WriteLine($"\n" + nameof(kolejnyWarunekSortowanaMalejacoNazwaAplikacjiNaKGame));
            Display(kolejnyWarunekSortowanaMalejacoNazwaAplikacjiNaKGame);
        }

        static void DivideData(IEnumerable<googleApp> app)
        {
            var niskaOcenaAplikacjiGame = app
                .Where(x => x.Rating < 3.2)
                .Where(x => x.Category == Category.GAME);
            var pierwszePiecNiskaOcenaAplikacjiGame = niskaOcenaAplikacjiGame.Take(5);
            var ostatniePiecNiskaOcenaAplikacjiGame = niskaOcenaAplikacjiGame.TakeLast(5);
            var wezWhileNiskaOcenaAplikacjiGame = niskaOcenaAplikacjiGame.TakeWhile(x=>x.Reviews >30);
            var pominPierwszeNiskaOcenaAplikacjiGame = niskaOcenaAplikacjiGame.Skip(10);
            var pominOstatnieNiskaOcenaAplikacjiGame = niskaOcenaAplikacjiGame.SkipLast(10);
            var pominWhileNiskaOcenaAplikacjiGame = niskaOcenaAplikacjiGame.SkipWhile(x=>x.Reviews > 30);
            Display(niskaOcenaAplikacjiGame);

            Console.WriteLine($"\n" + nameof(pominWhileNiskaOcenaAplikacjiGame));
            Display(pominWhileNiskaOcenaAplikacjiGame);
        }

        static void ProjectData(IEnumerable<googleApp> app)
        {
            var X = from n 
                    in app 
                    where n.Rating > 4.8 && n.Category == Category.SPORTS 
                    select n;

            var wysokaOcenaAplikacjiSports = app
                .Where(x => x.Rating > 4.8)
                .Where(x=>x.Category == Category.SPORTS);

            var wysokaOcenaAplikacjiSportsNazwa = wysokaOcenaAplikacjiSports.Select(x => x.Name);
            //Console.WriteLine(string.Join(Environment.NewLine, wysokaOcenaAplikacjiSportsNazwa));
            var wysokaOcenaAplikacjiSportsDTO = wysokaOcenaAplikacjiSports.Select(x => new googleAppDto()
            {
                Name = x.Name,
                Reviews = x.Reviews
            });
            //Console.WriteLine(string.Join(Environment.NewLine, wysokaOcenaAplikacjiSportsDTO.Select(x => x.Name)));
            foreach (var dto in wysokaOcenaAplikacjiSportsDTO)
            {
                //Console.WriteLine($"{dto.Name} : {dto.Reviews}");
            }
            var genres = wysokaOcenaAplikacjiSports.SelectMany(x => x.Genres);
            //Console.WriteLine(String.Join(" ", genres));

            var funkcjaAnonimowa = wysokaOcenaAplikacjiSports.Select(app => new
            {
                Reviews = app.Reviews,
                Name = app.Name,
                Category = app.Category
            });
            //Console.WriteLine(String.Join(Environment.NewLine, funkcjaAnonimowa));
        }

        static void GetData(IEnumerable<googleApp> app)
        {
            var wysokaOcenaAplikacji = app.Where(x => x.Rating > 4.6);
            var wysokaOcenaApikacjiBeauty = wysokaOcenaAplikacji.Where(x => x.Category == Category.BEAUTY);
            var pierwszaWysokaOcenaApikacjiBeauty = wysokaOcenaApikacjiBeauty.FirstOrDefault(x=>x.Reviews<500);
            var jednaWysokaOcenaApikacjiBeauty = wysokaOcenaApikacjiBeauty.SingleOrDefault(x=>x.Reviews<200);
            var ostatniaWysokaOcenaAplikacjiBeauty = wysokaOcenaApikacjiBeauty.LastOrDefault(x=>x.Reviews < 500);

            Display(wysokaOcenaApikacjiBeauty);

            Console.WriteLine($"\n"+nameof(ostatniaWysokaOcenaAplikacjiBeauty));
            Display(ostatniaWysokaOcenaAplikacjiBeauty);
        }

        static void Display(IEnumerable<googleApp> app)
        {
            foreach (var item in app)
            {
                Console.WriteLine(item);
            }
        }
        static void Display(googleApp app)
        {
            Console.WriteLine(app);
        }

        static List<googleApp> LoadGoogleAps(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<googleAppMap>();
                    var records = csv.GetRecords<googleApp>().ToList();
                    return records;
                }
            }
        }


        static void Smieci()
        {
            var sequence = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var squaresOfOddNumbers = from n in sequence
                                      where n % 2 == 1
                                      select n;
                        
            foreach (var number in squaresOfOddNumbers)
                Console.WriteLine(number);

            Console.WriteLine();
            var wypisz = sequence.Where(x => x > 5);
            foreach (var x in wypisz)
                Console.WriteLine(x);
        }
        //static List<googleApp> Czytaj()
        //{
        //    var sciezkaDoPliku = Directory.GetFiles("C:/Users/kryst/Desktop", "czyataj.csv", SearchOption.AllDirectories);
        //    FileStream fileStream = new FileStream(sciezkaDoPliku[0], FileMode.Open);
        //    StreamReader streamReader = new StreamReader(fileStream);

        //    string[] naglowekPliku = streamReader.ReadLine().Split(",");
        //    bool sprawdzPoprawnosc = Walidacja(naglowekPliku);
        //    List<googleApp> listaAplikacji = new List<googleApp>();
        //    if (sprawdzPoprawnosc)
        //    {
        //        while (streamReader.Peek() != -1)
        //        {
        //            var x = streamReader.ReadLine().Split(",");
        //            listaAplikacji.Add(new googleApp()
        //            {
        //                Name = x[0],
        //                Category = (Category)Enum.Parse(typeof(Category), x[1], true),
        //                Rating = x[2],
        //                Reviews = int.Parse(x[3]),
        //                Size = x[4],
        //                Installs = x[5],
        //                Type = (Type)Enum.Parse(typeof(Type), x[6], true),
        //                Price = decimal.Parse(x[7]),
        //                ContentRating = x[8],
        //                Genres = new List<string>() { x[9] },
        //                LastUpdated = DateTime.Parse(x[10])
        //            });
        //        }
        //    }
        //    fileStream.Close();
        //    return listaAplikacji;
        //}
        //static bool Walidacja(string[] naglowekPliku)
        //{
        //    bool zwrotka = true;
        //    googleApp app = new googleApp();

        //    if (naglowekPliku[0] != nameof(app.Name))
        //        zwrotka = false;
        //    if (naglowekPliku[1] != nameof(app.Category))
        //        zwrotka = false;
        //    if (naglowekPliku[2] != nameof(app.Rating))
        //        zwrotka = false;
        //    if (naglowekPliku[3] != nameof(app.Reviews))
        //        zwrotka = false;
        //    if (naglowekPliku[4] != nameof(app.Size))
        //        zwrotka = false;
        //    if (naglowekPliku[5] != nameof(app.Installs))
        //        zwrotka = false;
        //    if (naglowekPliku[6] != nameof(app.Type))
        //        zwrotka = false;
        //    if (naglowekPliku[7] != nameof(app.Price))
        //        zwrotka = false;
        //    if (naglowekPliku[8] != nameof(app.ContentRating))
        //        zwrotka = false;
        //    if (naglowekPliku[9] != nameof(app.Genres))
        //        zwrotka = false;
        //    if (naglowekPliku[10] != nameof(app.LastUpdated))
        //        zwrotka = false;
        //    return zwrotka;
        //}
    }
}
