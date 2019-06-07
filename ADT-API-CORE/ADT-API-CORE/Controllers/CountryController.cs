using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADT_API_CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADT_API_CORE.Controllers
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
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return await _context.Countrys
                .ToListAsync();
        }

        // GET: api/Country/countryId
        [HttpGet("{countryId}")]
        public async Task<ActionResult<Country>> GetByIdC(int countryId)
        {
            return (Country)await _context.Countrys
                .Where(u => u.CountryId == countryId)
                .FirstOrDefaultAsync();
        }
    }
}