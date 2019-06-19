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
    public class LoginController : ControllerBase
    {
        private readonly _Context _context;

        public LoginController(_Context context)
        {
            _context = context;
        }

        // POST: api/User {"Username": "", "Password": ""}
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User item)
        {
            return (User)await _context.Users
                .Where(u => u.UserName == item.UserName)
                .Include(u => u.Organization)
                .Include(u => u.Contact)
                .FirstOrDefaultAsync();
        }
    }
}