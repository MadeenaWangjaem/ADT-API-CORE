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
    public class RegisterController : ControllerBase
    {
        private _Context _context;
        private _Context _contextRepo;

        public RegisterController(_Context registerContext, _Context contextRepo)
        {
            this._context = registerContext;
            this._contextRepo = contextRepo;
        }

        //POST: api/register {User: {}, Contant: {}, Organization: {}}
        [HttpPost]
        public async Task<ActionResult<String>> PutUser([FromBody] User user)
        {
            String strRespon;
            ResponJson respon = new ResponJson();
            user.Contact.OrganizationID = null;
            user.Contact.Organization = null;
            using (var context = _contextRepo)
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // add organization
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
                        respon.message = "Insert user success";
                        //respon.user = user ;
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