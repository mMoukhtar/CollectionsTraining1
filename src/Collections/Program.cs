using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"c:\Users\Moham\CSharp\Collections1\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            //Code to be activated if you want to use Dictionary 
            var countries = reader.ReadCountries();

            Console.WriteLine ("Please Enter Country Code:");
            var code = Console.ReadLine();
            
            if (countries.TryGetValue(code,out Country country)){
                Console.WriteLine($"{country.Population}: {country.Name}");
            } else {
                Console.WriteLine($"Sorry there is no country with code, {code}");
            }





            // Code to be activated if you want to use List 
            // var countries = reader.ReadAllCountries();
            // var lilliput = new Country("Liliput","LIL","Somewhere",2000000);
            // var lilliputIndex = countries.FindIndex(x=>x.Population < 2000000);
            // countries.Insert(lilliputIndex,lilliput);

            // foreach (var country in countries){
            //     Console.WriteLine($"{country.Population}: {country.Name}");
            // }
        }
    }
}
 