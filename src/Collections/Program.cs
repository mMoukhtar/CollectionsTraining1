using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"c:\Users\Moham\CSharp\Collections1\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            var countries = reader.ReadAllCountries();

            var lilliput = new Country("Liliput","LIL","Somewhere",2000000);
            var lilliputIndex = countries.FindIndex(x=>x.Population < 2000000);
            countries.Insert(lilliputIndex,lilliput);

            foreach (var Country in countries){
                Console.WriteLine($"{Country.Population}: {Country.Name}");
            }
        }
    }
}
