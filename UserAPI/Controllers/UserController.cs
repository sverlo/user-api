using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET: /<controller>/

        public IUserRepository Users { get; set; }

        public UserController(IUserRepository users) => Users = users;

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            Users.Add(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        public IEnumerable<User> FindAll()
        {
            return Users.FindAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult FindById(string id)
        {
            var user = Users.Find(id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
                return BadRequest();

            var todo = Users.Find(id);
            if (todo == null)
                return NotFound();

            Users.Update(user);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = Users.Find(id);
            if (todo == null)
                return NotFound();

            Users.Delete(id);
            return new NoContentResult();
        }
    }
}
