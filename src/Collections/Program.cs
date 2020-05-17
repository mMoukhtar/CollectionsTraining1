using System;
using System.Linq;

namespace Collections
{
    class Program
    {

        public static void  OnAddCountry(object sender, EventArgs args){
            Console.WriteLine("Country Added");
        }
        static void Main(string[] args)
        {
            var filePath = @"c:\Users\Moham\CSharp\Collections1\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);
            reader.CountryAddedEvent += OnAddCountry;

            //Code to be activated if you want to use Dictionary 
            var countries = reader.ReadCountries();
            foreach (var region in countries.Keys){
                Console.WriteLine(region);
            }
            Console.Write("Please select a region: ");
            var regionKey = Console.ReadLine();
            if(!countries.ContainsKey(regionKey)){
                Console.WriteLine("Invalid Region!");
            } else {
                foreach (var country in countries[regionKey].Take(10)){
                    Console.WriteLine($"{country.Population}: {country.Name}");
                }

            }

       
            

            //Console.WriteLine ("Please Enter Country Code:");
            //var code = Console.ReadLine();
            
            //if (countries.TryGetValue(code,out Country country)){
            //    Console.WriteLine($"{country.Population}: {country.Name}");
            //} else {
            //    Console.WriteLine($"Sorry there is no country with code, {code}");
            //}



            // Code to be activated if you want to use List 
            // var countries = reader.ReadAllCountries();
            // var lilliput = new Country("Liliput","LIL","Somewhere",2000000);
            // var lilliputIndex = countries.FindIndex(x=>x.Population < 2000000);
            // countries.Insert(lilliputIndex,lilliput);

            // var filteredCountries1 = countries.OrderBy(x => x.Name).Take(10);
            // var filteredCountries2 = from country in countries
            //                         where !country.Name.Contains(',')
            //                         select country;

            // foreach (var country in filteredCountries2){ 
            //     Console.WriteLine($"{country.Population}: {country.Name}");
            // }
        }
    }
}
  