using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace MVCBasics.Models
{
    public static class CitiesModel
    {
        public static string GetCityName(List<City> list, int cityID)
        {
            IEnumerable<string> names = from city in list where city.ID == cityID select city.Name;

            if (names.ToList().Any())
            {
                return names.First();
            }
            else
            {
                return string.Empty;
            }
        }


        public static City GetCity(List<City> list, int cityID)
        {
            IEnumerable<City> cities = from city in list where city.ID == cityID select city;
            List<City> match = cities.ToList();

            if (match.Any())
            {
                return match.First();
            }
            else
            {
                return new City();
            }
        }


        public static bool CityExists(List<City> list, int cityID)
        {
            return list.Exists(city => city.ID == cityID);
        }
    }
}
