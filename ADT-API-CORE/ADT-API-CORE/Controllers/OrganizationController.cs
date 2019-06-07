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
    public class OrganizationController : ControllerBase
    {
        private readonly _Context _context;

        public OrganizationController(_Context context)
        {
            _context = context;
        }

        // GET: api/Organization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> Get()
        {
            return await _context.Organizations
                .ToListAsync();
        }

        // GET: api/Organization/organizationID
        [HttpGet("{organizationID}")]
        public async Task<ActionResult<Organization>> GetByIdO(int organizationID)
        {
            return (Organization)await _context.Organizations
                .Where(u => u.OrganizationID == organizationID)
                .FirstOrDefaultAsync();
        }
    }
}