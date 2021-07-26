using JWT_1.Helpers;
using JWT_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWT_1.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        JwtContext dbcontext = new JwtContext();
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("something is wrong");
                }

                var user = dbcontext.Users.Where(u => u.Name == model.Name && u.Password == model.Password)
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Roles
                })
                .FirstOrDefault();

                if (user == null)
                {
                    return BadRequest("Invalid User Name Or Password");
                }

                var token = TokenGenerator.GenerateToken(user.Id, user.Name, user.Roles);
                return Ok(token);

            }
            catch (Exception e)
            {
                return BadRequest("An Error has been accourd, " + e.Message);
            }


        }

        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(User model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest("Something wrong  ");


                }
                var user = dbcontext.Users.Where(u => u.Name == model.Name).FirstOrDefault();
                if (user != null)
                {
                    return BadRequest("User already exist ");

                }

                foreach(var role in model.Roles)
                {
                    dbcontext.Entry(role).State = EntityState.Unchanged;

                }


                dbcontext.Users.Add(model);
                dbcontext.SaveChanges();
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest("An Error has been accourd, " + e.Message);

            }


        }

    }
}
