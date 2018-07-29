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
                var result = this.userDataContext.Emails.Where(em => em.Address == userSession.Email).ToList();
                Email email = result.First();

                if (email != null)
                {
                    var user = this.userDataContext.Users.Find(email.UserId);

                    if (user != null)
                    {
                        return Json(user);
                    }
                    else
                    {
                        NotFound();
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
}
