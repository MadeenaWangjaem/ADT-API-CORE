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
    public class ProvinceController : ControllerBase
    {
        private readonly _Context _context;

        public ProvinceController(_Context context)
        {
            _context = context;
        }

        // GET: api/Province
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Province>>> Get()
        {
            return await _context.Provinces
                .Include(u => u.Country)
                .Include(u => u.Region)
                .ToListAsync();
        }

        // GET: api/Province/provinceID
        [HttpGet("{provinceID}")]
        public async Task<ActionResult<Province>> GetByIdP(int provinceID)
        {
            return (Province)await _context.Provinces
                .Where(u => u.ProvinceID == provinceID)
                .Include(u => u.Country)
                .Include(u => u.Region)
                .FirstOrDefaultAsync();
        }

        // GET: api/Province/Country/Region
        [HttpGet("{countryId}/{regionID}")]
        public async Task<ActionResult<IEnumerable<Province>>> GetByIdCR(int countryId, int regionID)
        {
            return await _context.Provinces
                .Include(u => u.Country)
                .Include(u => u.Region)
                .Where(u => u.Country.CountryId == countryId)
                .Where(u => u.Region.RegionID == regionID)
                .ToListAsync();
        }

        // POST: api/Province{name}
        [HttpPost]
        public async Task<ActionResult<Province>> GeyByName([FromBody] Province item)
        {
            return (Province)await _context.Provinces
                .Where(u => u.Name == item.Name)
                .Include(u => u.Country)
                .Include(u => u.Region)
                .FirstOrDefaultAsync();
           
        }

    }
}
