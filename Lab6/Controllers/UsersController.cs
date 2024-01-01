using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Lab6.Models;

namespace Lab6.Controllers
{
        [Route("api/[controller]")]
    public class UsersController : Controller
    {
        UsersContext db;
        public UsersController(UsersContext context)
        {
            this.db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Name = "Tom", Age = 26 });
                db.Users.Add(new User { Name = "Alice", Age = 31 });
                db.SaveChanges();
            }
        }
 
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user==null)
            {
                ModelState.AddModelError("", "Не указаны данные для пользователя");
                return BadRequest(ModelState);
            }
            // обработка частных случаев валидации
            if (user.Age==99)
                ModelState.AddModelError("Age", "Возраст не должен быть равен 99");
 
            if (user.Name == "admin")
            {
                ModelState.AddModelError("Name", "Недопустимое имя пользователя - admin");
            }
            // если есть ошибки - возвращаем ошибку 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
 
            // если ошибок нет, сохраняем в базу данных
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            db.SaveChanges();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}

