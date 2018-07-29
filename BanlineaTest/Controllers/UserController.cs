using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Data;

namespace BanlineaTest.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly UserDataContext userDataContext;

        public UserController(UserDataContext userDataContext)
        {
            this.userDataContext = userDataContext;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            return Json(this.userDataContext.Users.ToList());
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            return Json(this.userDataContext.Users.Find(id));
        }

        // GET: api/User/5/5
        [HttpGet("{id}/Emails", Name = "GetEmails")]
        public IActionResult GetEmails(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var emails = this.userDataContext.Emails.Where(email => email.UserId == id).ToList();
            return Json(emails);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User.Data.User user)
        {
            this.userDataContext.SaveChanges();
            Ok();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User.Data.User user)
        {
            if (id <= 0)
            {
                NotFound();
            }

            this.userDataContext.Users.Update(user);
            this.userDataContext.SaveChanges();
            Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id <= 0)
            {
                NotFound();
            }

            User.Data.User user = this.userDataContext.Users.Find(id);
            this.userDataContext.Users.Remove(user);
            this.userDataContext.SaveChanges();
            Ok();
        }
    }
}
