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
    public class Cities : ControllerBase
    {
        private readonly ApplicationDBContext Database;

        public Cities(ApplicationDBContext database)
        {
            Database = database;
        }


        public IQueryable<CityDTO> GetAll()
        {
            var cities = from city in Database.Cities
                            select new CityDTO()
                            {
                                ID = city.ID,
                                Name = city.Name,
                            };

            return cities;
        }

    }
}
