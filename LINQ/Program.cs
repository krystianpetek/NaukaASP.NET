// wczytanie csv
// where
// first, single, last, firstordefault, singleordefault

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
            string csvPath = $"C:/GITHUB/NaukaASP.NET/LINQ/googleplaystore1.csv";
            var app = LoadGoogleAps(csvPath);

            //Display(app);
            GetData(app);
        }
        
        static void GetData(IEnumerable<googleApp> app)
        {
            var wysokaOcenaAplikacji = app.Where(x => x.Rating > 4.9);
            Display(wysokaOcenaAplikacji);
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
