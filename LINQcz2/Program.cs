using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
namespace LINQcz2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ustawDirectory();
            var people = LoadPeople();
            var addresses = LoadAddresses();

            //foreach(Person person in people)
            //{
            //    var address = addresses.FirstOrDefault(x=>x.PersonId == person.Id);
            //    if(address != null)
            //    Console.WriteLine($"Name: {person.Name}, address: {address.City}, {address.Street}");
            //}
            Console.WriteLine("JOIN");
            var polaczoneDane = people.Join
                (addresses,
                p=>p.Id,
                a=>a.PersonId,
                (people,addresses) => new { people.Name, addresses.Street, addresses.City });

            foreach(var element in polaczoneDane)
            {
                Console.WriteLine($"Name: {element.Name}, address: {element.City}, {element.Street}");
            }

            Console.WriteLine("GROUPJOIN - wszystkie osoby wypisane");
            var polaczoneDaneGrupowanie = people.GroupJoin
                (addresses,
                p => p.Id,
                a => a.PersonId,
                (people, addresses) => new { people.Name, Addresses = addresses});

            foreach (var element in polaczoneDaneGrupowanie)
            {
                Console.WriteLine($"Name: {element.Name}");
                foreach(var address in element.Addresses)
                {
                    Console.WriteLine($"\t City: {address.City}, street: {address.Street}");
                }
            }

            Console.WriteLine();
            var polaczoneDaneLewoStronnie= people.Join
                (addresses,
                p => p.Id,
                a => a.PersonId,
                (people, addresses) => people.Name + " " + people.Id + " " + addresses.Street+ " "+ addresses.City);

            foreach(var item in polaczoneDaneLewoStronnie)
            {
                Console.WriteLine(item);
            }
        }

        private static void ustawDirectory()
        {
            Directory.SetCurrentDirectory("../../../");
        }

        private static List<Person> LoadPeople()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var jsonPath = Path.GetRelativePath(currentDirectory, "People.json");
            var json = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<List<Person>>(json);
        }
        private static List<Address> LoadAddresses()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var jsonPath = Path.GetRelativePath(currentDirectory, "Addresses.json");
            var json = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<List<Address>>(json);
        }

    }
}
