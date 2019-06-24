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
    public class LoginDbController : ControllerBase
    {
        private readonly _Context _context;

        public LoginDbController(_Context context)
        {
            _context = context;
        }

        // POST: api/LoginDb {"Username": "", "Password": ""}
        [HttpPost]
        public async Task<ActionResult<string>> loginDb(User user)
        {
            user.Organization   = null;
            user.Contact        = null;
            //Console.WriteLine(SHA.GenerateSHA512String("abc"));
            String hashPassword = hashSHA.GenerateSHA512String(user.Password);
            User responUser = (User)await _context.Users
                .Where(u    => u.UserName == user.UserName)
                .Where(u    => u.Password == hashPassword)
                .FirstOrDefaultAsync();

            return HelperLoginDb.checkNull(responUser);
            //return "sad";
        }
    }
    public class HelperLoginDb
    {

        public static string checkNull(User user)
        {
            ResponJson responJson = new ResponJson();
            string strRespon;
            if (user != null)
            {
                responJson.status   = true;
                responJson.message  = "Success";
                responJson.id     = user.UserID;
                strRespon = Newtonsoft.Json.JsonConvert.SerializeObject(responJson);

                return strRespon;
            }
            else
            {
                responJson.status   = false;
                responJson.message  = "Fail";
                responJson.id     = -1;
                strRespon           = Newtonsoft.Json.JsonConvert.SerializeObject(responJson);

                return strRespon;
            }
        }
    }
}