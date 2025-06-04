using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AdvancedProgrammingTechniques
{
    // Data models
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int Height { get; set; }
        public string Allergies { get; set; }

        public Person(string firstName, string lastName, string city, int height, string allergies)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Height = height;
            Allergies = allergies;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} from {City} (Height: {Height}cm)" +
                   (Allergies != null ? $" - Allergies: {Allergies}" : "");
        }
    }

    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public override string ToString()
        {
            return $"{Name} (Population: {Population:N0})";
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Data setup
            int[] numbers = { 106, 104, 10, 5, 117, 174, 95, 61, 74, 145, 77, 95, 72, 59, 114, 95, 61, 116, 106, 66, 75, 85, 104, 62, 76, 87, 70, 17, 141, 39, 199, 91, 37, 139, 88, 84, 15, 166, 118, 54, 42, 123, 53, 183, 95, 101, 112, 26, 41, 135, 70, 48, 59, 69, 109, 93, 110, 153, 178, 117, 5 };

            City[] cities = {
                new City("Toronto", 100200),
                new City("Hamilton", 80923),
                new City("Ancaster", 4039),
                new City("Brantford", 500890),
            };

            Person[] persons = {
                new Person("Cedric","Coltrane","Toronto",157,null),
                new Person("Hank","Spencer","Peterborough",158,"Sulfa, Penicillin"),
                new Person("Sara","di","29",145,null),
                new Person("Daphne ","Seabright","Ancaster",146,null),
                new Person("Rick","Bennett","Ancaster",220,null),
                new Person("Amy","Leela","Hamilton",172,"Penicillin"),
                new Person("Woody","Bashir","Barrie",153,null),
                new Person("Tom", "Halliwell","Hamilton",179,"Codeine, Sulfa"),
                new Person("Rachel ","Winterbourne","Hamilton",163,null),
                new Person("John","West","Oakville",138,null),
                new Person("Jon","Doggett","Hamilton",194,"Peanut Oil"),
                new Person("Angel","Edwards","Brantford",176,null),
                new Person("Brodie","Beck","Carlisle",157,null),
                new Person("Beanie","Foster","Ancaster",154,"Ragweed, Codeine"),
                new Person("Nino","Andrews","Hamilton",186,null),
                new Person("John","Farley","Hamilton",213,null),
                new Person("Nea","Kobayakawa","Toronto",147,null),
                new Person("Laura","Halliwell","Brantford",146,null),
                new Person("Lucille","Maureen","Hamilton",184,null),
                new Person("Jim","Thoma","Ottawa",173,null),
                new Person("Roderick","Payne","Halifax",58,null),
                new Person("Sam","Threep","Hamilton",199,null),
                new Person("Bertha","Crowley","Delhi",125,"Peanuts, Gluten"),
                new Person("Roland","Edge","Brantford",199,null),
                new Person("Don","Wiggum","Hamilton",189,null),
                new Person("Anthony","Maxwell","Oakville",92,null),
                new Person("James","Sullivan","Delhi",139,null),
                new Person("Anne","Marlowe","Pickering",165,"Peanut Oil"),
                new Person("Kelly","Hamilton","Stoney",84,null),
                new Person("Charles","Andonuts","Hamilton",62,null),
                new Person("Temple ","Russert","Hamilton",166,"Sulphur"),
                new Person("Don","Edwards","Hamilton",215,null),
                new Person("Alice","Donovan","Hamilton",167,null),
                new Person("Stone","Cutting","Hamilton",110,null),
                new Person("Neil","Allan","Cambridge",203,null),
                new Person("Cross","Gordon","Ancaster",125,null),
                new Person("Phoebe","Bigelow","Thunder",183,null),
                new Person("Harry","Kuramitsu","Hamilton",210, null)
            };

            Console.WriteLine("=== LINQ Lab Exercises ===\n");

            // Exercise 1: Number operations
            NumberOperations(numbers);

            // Exercise 2: Person operations
            PersonOperations(persons, cities);

            // Exercise 3: XML conversion
            XmlOperations(persons);
        }

        private static void NumberOperations(int[] numbers)
        {
            Console.WriteLine("1. NUMBER OPERATIONS\n");

            // 1a. Select numbers greater than 80
            Console.WriteLine("1a. Numbers greater than 80:");

            // Query syntax
            var greaterThan80Query = from n in numbers
                                     where n > 80
                                     select n;
            Console.WriteLine("Query syntax: " + string.Join(", ", greaterThan80Query));

            // Method syntax
            var greaterThan80Method = numbers.Where(n => n > 80);
            Console.WriteLine("Method syntax: " + string.Join(", ", greaterThan80Method));

            // 1b. Order numbers, descending
            Console.WriteLine("\n1b. Numbers ordered descending:");

            // Query syntax
            var orderedDescQuery = from n in numbers
                                   orderby n descending
                                   select n;
            Console.WriteLine("Query syntax: " + string.Join(", ", orderedDescQuery.Take(10)) + "...");

            // Method syntax
            var orderedDescMethod = numbers.OrderByDescending(n => n);
            Console.WriteLine("Method syntax: " + string.Join(", ", orderedDescMethod.Take(10)) + "...");

            // 1c. Transform numbers into "Have number #n"
            Console.WriteLine("\n1c. Transform to 'Have number #n':");

            // Query syntax
            var transformedQuery = from n in numbers
                                   select $"Have number #{n}";
            Console.WriteLine("Query syntax (first 5): " + string.Join(", ", transformedQuery.Take(5)) + "...");

            // Method syntax
            var transformedMethod = numbers.Select(n => $"Have number #{n}");
            Console.WriteLine("Method syntax (first 5): " + string.Join(", ", transformedMethod.Take(5)) + "...");

            // 1d. Count numbers between 70 and 100
            Console.WriteLine("\n1d. Count numbers between 70 and 100:");

            var numbersInRange = from n in numbers
                                 where n > 70 && n < 100
                                 select n;
            int count = numbersInRange.Count();
            Console.WriteLine($"Count: {count}");

            Console.WriteLine();
        }

        private static void PersonOperations(Person[] persons, City[] cities)
        {
            Console.WriteLine("2. PERSON OPERATIONS\n");

            // 2a. Select persons with particular height (wrapped in function)
            Console.WriteLine("2a. Persons with height 180 or above:");
            var tallPersons = SelectPersonsByHeight(persons, 180);
            foreach (var person in tallPersons.Take(5))
            {
                Console.WriteLine($"  {person}");
            }

            // 2b. Transform names: John Doe -> J. Doe
            Console.WriteLine("\n2b. Transform names to J. Doe format:");

            // Query syntax
            var transformedNamesQuery = from p in persons
                                        select $"{p.FirstName.First()}. {p.LastName}";
            Console.WriteLine("Query syntax (first 5): " + string.Join(", ", transformedNamesQuery.Take(5)));

            // Method syntax
            var transformedNamesMethod = persons.Select(p => $"{p.FirstName.First()}. {p.LastName}");
            Console.WriteLine("Method syntax (first 5): " + string.Join(", ", transformedNamesMethod.Take(5)));

            // 2c. Select all distinct allergies
            Console.WriteLine("\n2c. All distinct allergies:");

            // Query syntax
            var allergiesQuery = (from p in persons
                                  where p.Allergies != null
                                  from allergy in p.Allergies.Split(',')
                                  select allergy.Trim()).Distinct();
            Console.WriteLine("Query syntax: " + string.Join(", ", allergiesQuery));

            // Method syntax
            var allergiesMethod = persons
                .Where(p => p.Allergies != null)
                .SelectMany(p => p.Allergies.Split(','))
                .Select(a => a.Trim())
                .Distinct();
            Console.WriteLine("Method syntax: " + string.Join(", ", allergiesMethod));

            // 2d. Count cities that start with "H"
            Console.WriteLine("\n2d. Number of cities starting with 'H':");
            var hCitiesCount = persons.Select(p => p.City).Distinct().Count(c => c.StartsWith("H"));
            Console.WriteLine($"Count: {hCitiesCount}");

            // 2e. Join with cities and select persons from cities with population > 100,000
            Console.WriteLine("\n2e. Persons from cities with population > 100,000:");
            var personsFromBigCities = from p in persons
                                       join c in cities on p.City equals c.Name
                                       where c.Population > 100000
                                       select p;
            foreach (var person in personsFromBigCities)
            {
                Console.WriteLine($"  {person}");
            }

            // 2f. Manual city list filtering
            Console.WriteLine("\n2f. Filter by manual city list:");
            string[] targetCities = { "Hamilton", "Toronto", "Brantford" };

            // Persons IN the target cities
            var personsInCities = persons.Where(p => targetCities.Contains(p.City));
            Console.WriteLine($"Persons in target cities ({personsInCities.Count()}):");
            foreach (var person in personsInCities.Take(5))
            {
                Console.WriteLine($"  {person}");
            }

            // Persons NOT in the target cities
            var personsNotInCities = persons.Where(p => !targetCities.Contains(p.City));
            Console.WriteLine($"\nPersons NOT in target cities ({personsNotInCities.Count()}):");
            foreach (var person in personsNotInCities.Take(5))
            {
                Console.WriteLine($"  {person}");
            }

            Console.WriteLine();
        }

        // 2a. Function to select persons by height
        private static IEnumerable<Person> SelectPersonsByHeight(Person[] persons, int minHeight)
        {
            // Query syntax
            var queryResult = from p in persons
                              where p.Height >= minHeight
                              select p;

            // Method syntax (alternative implementation)
            // var methodResult = persons.Where(p => p.Height >= minHeight);

            return queryResult;
        }

        private static void XmlOperations(Person[] persons)
        {
            Console.WriteLine("3. XML OPERATIONS\n");

            // Convert persons list to XML using LINQ and XElement
            var personsXml = new XElement("Persons",
                from p in persons
                select new XElement("Person",
                    new XAttribute("firstName", p.FirstName),
                    new XAttribute("lastName", p.LastName),
                    new XElement("City", p.City),
                    new XElement("Height", p.Height),
                    p.Allergies != null ? new XElement("Allergies", p.Allergies) : null
                )
            );

            Console.WriteLine("3. Persons converted to XML (first 5 entries):");

            // Show first 5 person elements
            var firstFivePersons = personsXml.Elements("Person").Take(5);
            var sampleXml = new XElement("Persons", firstFivePersons);

            Console.WriteLine(sampleXml.ToString());

            Console.WriteLine("\n... (XML contains all persons)");
            Console.WriteLine($"Total persons in XML: {personsXml.Elements("Person").Count()}");
        }
    }
}
