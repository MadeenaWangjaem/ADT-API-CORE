using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADT.API.CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADT.API.CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly _Context _context;
        public CountryController(_Context context)
        {
            _context = context;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            return await _context.Countrys
                .ToListAsync();
        }
    }
}