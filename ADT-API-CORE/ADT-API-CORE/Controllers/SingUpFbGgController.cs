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
    public class SingUpFbGgController : ControllerBase
    {
        private _Context _context;
        private _Context _contextRepo;

        public SingUpFbGgController(_Context registerContext, _Context contextRepo)
        {
            _context = registerContext;
            _contextRepo = contextRepo;
        }

        //POST: api/register {User: {}, Contant: {}, Organization: {}}
        [HttpPost]
        public async Task<ActionResult<String>> singUpFbGg([FromBody] User user)
        {
            String strRespon;
            ResponJson respon = new ResponJson();
            // Clear because data insert 2 time
            user.Contact.OrganizationID = null;
            user.Contact.Organization = null;

            // Check userName in Database
            User acc = (User)await _context.Users
               .Where(u => u.UserName == user.UserName)
               .Include(u => u.Organization)
               .Include(u => u.Contact)
               .FirstOrDefaultAsync();
            // if true userName is unavailable
            if (acc != null)
            {
                respon.status = false;
                respon.message = "UserName is unavailable";
                strRespon = Newtonsoft.Json.JsonConvert.SerializeObject(respon);
                return strRespon;
            }
            using (var context = _contextRepo)
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // Add organization
                        await context.Organizations.AddAsync(user.Organization);
                        await context.SaveChangesAsync();

                        // ADD Contact
                        await context.Contacts.AddAsync(user.Contact);
                        await context.SaveChangesAsync();

                        // ADD User
                        await context.Users.AddAsync(user);
                        await context.SaveChangesAsync();

                        dbContextTransaction.Commit();


                        respon.status = true;
                        respon.message = "Sing up success";
                        //respon.id = user. ;
                        strRespon = Newtonsoft.Json.JsonConvert.SerializeObject(respon);

                        return strRespon;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();

                        respon.status = false;
                        respon.message = ex.Message;
                        strRespon = Newtonsoft.Json.JsonConvert.SerializeObject(respon);
                    }
                }
            }
            return strRespon;
        }
    }
}