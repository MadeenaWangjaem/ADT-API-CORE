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
    public class UserController : ControllerBase
    {
        private readonly _Context _context;

        public UserController(_Context context)
        {
            _context = context;
        }
        // POST: api/User{username,password}
        // POST: api/Province{name}
        [HttpPost]
        public ActionResult<User> Create([FromBody] User item)
        {
            return item;

        }
        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users
                .Include(u => u.Organization)
                .Include(u => u.Contact)
                .ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
