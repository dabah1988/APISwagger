using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CityManager.WebAPI.DatabaseContext;
using CityManager.WebAPI.models;

namespace CityManager.WebAPI.Controllers.v2
{
    //[Route("api/[controller]")]
    //[ApiController]
    /// <summary>
    /// La version 2 de l'API
    /// </summary>
    [ApiVersion("2.0")]
    public class CitiesController : CustomController
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        /// <summary>
        /// Retourne toutes les villes 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string?>>> GetCities()
        {
            var cities =  await _context.Cities
                .OrderBy(city => city.cityName)
                .Select(city => city.cityName)
                . ToListAsync();
            return cities;
        }

 

        
 

    }
}
