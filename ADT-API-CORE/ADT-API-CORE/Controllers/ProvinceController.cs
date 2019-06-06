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
        public async Task<ActionResult<IEnumerable<Province>>> GetProvince()
        {
            return await _context.Provinces
                .Include(u => u.Country)
                .Include(u => u.Region)
                .ToListAsync();
        }
        // GET: api/Province{name}
        [HttpGet("{name}")]
        public async Task<ActionResult<Province>> Get(string name)
        {
            return (Province)await _context.Provinces
                .Where(u => u.Name == name)
                .Include(u => u.Country)
                .Include(u => u.Region)
                .FirstOrDefaultAsync();
        }
        // GET: api/Province{Country,Region}

        [HttpGet("{country}/{region}")]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvince(string country, string region)
        {
            return await _context.Provinces
                .Include(u => u.Country)
                .Include(u => u.Region)
                .Where(u => u.Country.Name == country)
                .Where(u => u.Region.Name == region)
                .ToListAsync();
        }
        // POST: api/Province{name}
        [HttpPost]
        public async Task<ActionResult<Province>> Create([FromBody] Province item)
        {
            return (Province)await _context.Provinces
                .Where(u => u.Name == item.Name)
                .Include(u => u.Country)
                .Include(u => u.Region)
                .FirstOrDefaultAsync();
           
        }

    }
}
