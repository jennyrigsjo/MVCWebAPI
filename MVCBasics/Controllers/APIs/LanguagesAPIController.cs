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
    public class Languages : ControllerBase
    {
        private readonly ApplicationDBContext Database;

        public Languages(ApplicationDBContext database)
        {
            Database = database;
        }


        public IQueryable<LanguageDTO> GetAll()
        {
            var languages = from l in Database.Languages
                            select new LanguageDTO()
                            {
                                ID = l.ID,
                                Name = l.Name,
                            };

            return languages;
        }

    }
}
