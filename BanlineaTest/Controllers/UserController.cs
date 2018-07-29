﻿using System;
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

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
