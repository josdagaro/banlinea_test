using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BanlineaTest.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller

    {
        [HttpPost("[action]")]
        public IActionResult Start([FromBody]User user)
        {
            if (ModelState.IsValid) {
                return Json(user);
            }

            return BadRequest();
        }
    }

    public class User
    {
        [Required]
        public string Email { set; get; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Pwd { set; get; }
    }
}
