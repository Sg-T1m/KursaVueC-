using KursaVue.Model;
using KursaVue.Repository;
using KursaVue.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KursaVue.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private DbContextProductShop db = new DbContextProductShop();
        private DbWork DbWork = new DbWork();
        // GET: api/<LoginController>

        [HttpGet]
        [Authorize]
        public string Get()
        {
            var req = (User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            string name = req.Value;
            var user = DbWork.GetUser(name);
            string TypeUser = user[0].TypeUsers;
            return TypeUser;
        }

     
        [HttpPost]
        public IActionResult Post([FromBody] Authorization authorizationData)
        {

            var user = DbWork.GetUser(authorizationData.Username);
            if (user.Count >= 1)
            {
               if (Md5Services.hashPassword(authorizationData.Password) == user[0].Password)
                {
                    string token = TokenGeneration.GenerationToken(authorizationData.Username);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Неверный пароль");
                }
                    
            }
            else
            {
                return Unauthorized("Такого логина не существует");
            }
           
         
        }

    
    }
}
