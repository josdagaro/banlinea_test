using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Json(this.userDataContext.Users.ToList());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            return Json(this.userDataContext.Users.Find(id));
        }

        [HttpGet("{id}/Emails", Name = "GetEmails")]
        public IActionResult GetEmails(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            User.Data.User user = this.userDataContext.Users.AsNoTracking().Where(u => u.Id == id).First();

            if (user == null)
            {
                return NotFound();
            }

            var emails = this.userDataContext.Emails.Where(email => email.UserId == id).ToList();
            return Json(emails);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User.Data.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            List<User.Data.User> oldUsers = this.userDataContext.Users.AsNoTracking().Where(old => old.DocumentTypeId == user.DocumentTypeId && old.DocumentId == user.DocumentId).ToList();

            if (oldUsers.Count() > 0)
            {
                foreach (var oldUser in oldUsers)
                {
                    if (oldUser.DocumentTypeId == user.DocumentTypeId && oldUser.DocumentId == user.DocumentId)
                    {
                        return BadRequest();
                    }
                }
            }

            this.userDataContext.Add(user);
            this.userDataContext.SaveChanges();
            User.Data.User newUser = this.userDataContext.Users.AsNoTracking().Where(newU => newU.DocumentTypeId == user.DocumentTypeId && newU.DocumentId == user.DocumentId).First();
            return Json(newUser);
        }

        [HttpPost("email/creation", Name = "CreateEmail")]
        public IActionResult CreateEmail([FromBody]User.Data.Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                List<User.Data.Email> oldEmails = this.userDataContext.Emails.Where(old => old.Address == email.Address).ToList(); ;

                if (oldEmails.Count() > 0)
                {
                    return BadRequest();
                }

                this.userDataContext.Emails.Add(email);
                this.userDataContext.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User.Data.User user)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                User.Data.User oldU = this.userDataContext.Users.AsNoTracking().Where(u => u.Id == id).First();

                if (oldU == null)
                {
                    return NotFound();
                }
            }

            List<User.Data.User> oldUsers = this.userDataContext.Users.AsNoTracking().Where(old => old.DocumentTypeId == user.DocumentTypeId && old.DocumentId == user.DocumentId).ToList();

            if (oldUsers.Count() > 0)
            {
                foreach (var oldUser in oldUsers)
                {
                    if (oldUser.Id != user.Id && oldUser.DocumentTypeId == user.DocumentTypeId && oldUser.DocumentId == user.DocumentId)
                    {
                        return BadRequest();
                    }
                }
            }

            this.userDataContext.Users.Update(user);
            this.userDataContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            User.Data.User user = this.userDataContext.Users.AsNoTracking().Where(u => u.Id == id).First();

            if (user == null)
            {
                return NotFound();
            }

            this.userDataContext.Users.Remove(user);
            this.userDataContext.SaveChanges();
            return Ok();
        }
    }
}
