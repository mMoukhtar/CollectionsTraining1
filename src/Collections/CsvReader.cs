using System.Collections.Generic;
using System.IO;

namespace Collections
{
    class CsvReader
    {
        private string filePath;

        public CsvReader(string filePath)
        {
            this.filePath = filePath;
        }

        public Dictionary<string,Country> ReadCountries(){
            using (var reader = new StreamReader(filePath)){
                reader.ReadLine();
                var countries = new Dictionary<string,Country>();
                while (reader.Peek() > 0) 
                {
                    var country = ReadCountryFromCsvLine(reader.ReadLine());
                    countries.Add(country.Code,country);
                }
                return countries;
            }
        }

        public List<Country> ReadAllCountries(){
            using (var reader = new StreamReader(filePath)){
                reader.ReadLine();
                var list = new List<Country>();
                while (reader.Peek() > 0) 
                {
                    var stringLine = reader.ReadLine();
                    list.Add(ReadCountryFromCsvLine(stringLine));
                }
                return list;
            }
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                for (var i = 0 ; i < countries.Length ; i++)
                {
                    var stringLine = reader.ReadLine();
                    countries[i] = ReadCountryFromCsvLine(stringLine);
                }
            }
            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            var parts = csvLine.Split(",");
            var name=string.Empty;
            var code=string.Empty;
            var region=string.Empty;
            var popText=string.Empty;
            var population = 0;
            switch(parts.Length)
            {
                case 4:
                {
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                }
                case 5:
                {
                    name = parts[0] + parts[1];
                    name = name.Replace("\"",null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                }
                default:
                {
                    throw new InvalidDataException($"Invalid Country Data {csvLine}");
                }
            }
            int.TryParse(popText,out population);
            return new Country(name,code,region,population);
        }
    }
}