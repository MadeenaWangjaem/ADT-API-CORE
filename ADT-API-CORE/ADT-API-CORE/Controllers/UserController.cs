using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADT_API_CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADT_API_CORE
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
        
        // GET: api/User ssssscsc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.Users 
                .Include(u => u.Organization)
                .Include(u => u.Contact)
                .ToListAsync();
        }

        // GET: api/User/userName
        [HttpGet("{userName}")]
        public async Task<ActionResult<String>> GetByIdP(String userName)
        {
            User acc = (User)await _context.Users
                .Where(u   => u.UserName == userName)
                .Include(u => u.Organization)
                .Include(u => u.Contact)
                .FirstOrDefaultAsync();
            ResponJson jsonRe = new ResponJson();
            String jsonString;
            if (acc != null)
            {
                jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(acc);
                jsonRe.status   = true;
                jsonRe.message  = "Success Respon 55";
                jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonRe);
                return jsonString;
            }
            jsonRe.status = false;
            jsonRe.message = "messageError555";
           
            jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonRe);
            return jsonString;
        }

        // POST: api/User {"Username": "", "Password": ""}
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User item)
        {
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }
        //[HttpPost]
        //public async Task<ActionResult<User>> Create([FromBody] User item)
        //{
        //    return (User)await _context.Users
        //        .Where(u => u.UserName == item.UserName)
        //        .Where(u => u.Password == item.Password)

        //        .FirstOrDefaultAsync();
        //}


    }
}
