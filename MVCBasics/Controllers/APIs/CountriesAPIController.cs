using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.Models.DTOs;
using MVCBasics.ViewModels;
using System;

namespace MVCBasics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyContactsApp")]
    public class Countries : ControllerBase
    {
        private readonly ApplicationDBContext Database;

        public Countries(ApplicationDBContext database)
        {
            Database = database;
        }


        public IQueryable<CountryDTO> GetAll()
        {
            var countries = from country in Database.Countries
                            select new CountryDTO()
                            {
                                ID = country.ID,
                                Name = country.Name,
                                Cities = country.Cities.Select(city => new CityDTO()
                                {
                                    ID = city.ID,
                                    Name=city.Name,
                                }).ToList()
                            };

            return countries;
        }


        [HttpGet("{id}", Name = "GetCountry")]
        public IActionResult GetById(int id)
        {
            var countries = from country in Database.Countries
                            where country.ID == id
                            select new CountryDTO()
                            {
                                ID = country.ID,
                                Name = country.Name,
                                Cities = country.Cities.Select(city => new CityDTO()
                                {
                                    ID = city.ID,
                                    Name = city.Name,
                                }).ToList()
                            };

            if (countries.Any())
            {
                return new ObjectResult(countries.First());
            }
            else
            {
                return NotFound();
            }
        }

    }
}
