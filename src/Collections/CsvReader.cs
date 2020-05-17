using System.Collections.Generic;
using System.IO;
using System;

namespace Collections
{
    public delegate void CountryAddedDelegate(object sender, EventArgs args);
    class CsvReader
    {
        private string filePath;
        public event CountryAddedDelegate CountryAddedEvent;

        public CsvReader(string filePath)
        {
            this.filePath = filePath;
        }

        public Dictionary<string, List<Country>> ReadCountries()
        {
            var countries = new Dictionary<string, List<Country>>();
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();

                while (reader.Peek() > 0)
                {
                    var country = ReadCountryFromCsvLine(reader.ReadLine());
                    if (countries.ContainsKey(country.Region))
                    {
                        countries[country.Region].Add(country);
                    }
                    else
                    {
                        var list = new List<Country>();
                        list.Add(country);
                        countries.Add(country.Region, list);
                    }
                    if (CountryAddedEvent != null)
                    {
                        CountryAddedEvent(this, new EventArgs());
                    }
                }
                return countries;
            }
        }

        public List<Country> ReadAllCountries()
        {
            using (var reader = new StreamReader(filePath))
            {
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
                for (var i = 0; i < countries.Length; i++)
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
            var name = string.Empty;
            var code = string.Empty;
            var region = string.Empty;
            var popText = string.Empty;
            var population = 0;
            switch (parts.Length)
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
                        name = name.Replace("\"", null).Trim();
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
            int.TryParse(popText, out population);
            return new Country(name, code, region, population);
        }
    }
}