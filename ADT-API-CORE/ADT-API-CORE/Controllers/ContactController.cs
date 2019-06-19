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
    public class ContactController : ControllerBase
    {
        private readonly _Context _context;

        public ContactController(_Context context)
        {
            _context = context;
        }
        // GET: api/Province
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            return await _context.Contacts
                .Include(u => u.Organization)
                .ToListAsync();
        }
        // POST: api/Contact { ContactID: }
        [HttpPost]
        public async Task<ActionResult<Contact>> GetByIdC([FromBody] Contact item)
        {
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }
        //[HttpPost]
        //public async Task<ActionResult<Contact>> GetByIdC([FromBody] Contact item)
        //{
        //    return (Contact)await _context.Contacts
        //        .Where(u => u.ContactID == item.ContactID)
        //        .Where(u => u.OrganizationID == item.OrganizationID)
        //        .Include(u => u.Organization)
        //        .FirstOrDefaultAsync();
        //}

        [HttpGet("{contactID}/{organizationID}")]
        public async Task<ActionResult<Contact>> GetByIdCO(int contactID,int organizationID)
        {
            return await _context.Contacts
                .Where(u => u.ContactID == contactID)
                .Where(u => u.OrganizationID == organizationID)
                .Include(u => u.Organization)
                .FirstOrDefaultAsync();
        }

    }
}