using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using User.Data;

namespace BanlineaTest.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly UserDataContext userDataContext;

        public SessionController(UserDataContext userDataContext)
        {
            this.userDataContext = userDataContext;
        }

        [HttpPost("[action]")]
        public IActionResult Start([FromBody]UserSession userSession)
        {
            if (ModelState.IsValid)
            {
                Email email = this.userDataContext.Emails.FirstOrDefault(mail => mail.Address == userSession.Email);

                if (email != null)
                {
                    var user = this.userDataContext.Users.Find(email.UserId);

                    if (user != null)
                    {
                        SessionResponse sessionResponse = new SessionResponse(email.Address, user.Name);
                        return Json(sessionResponse);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }
    }

    public class UserSession
    {
        [Required]
        public string Email { set; get; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Pwd { set; get; }
    }

    public class SessionResponse
    {
        public SessionResponse(string Email, string Name)
        {
            this.Email = Email;
            this.Name = Name;
        }

        public string Email { set; get; }

        public string Name { set; get; }
    }
}
