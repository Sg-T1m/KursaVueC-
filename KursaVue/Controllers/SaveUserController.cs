using KursaVue.Model;
using KursaVue.Repository;
using KursaVue.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KursaVue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaveUserController : ControllerBase
    {
       

        // POST api/<SaveUserController>
        [HttpPost]
        public IActionResult Post([FromBody] List<RegistrationDataUser> dataUser)
        {
            List<User> users = new List<User>() { new User() { Id = dataUser[0].Id, PersonalDataId = dataUser[0].Id, Password = Md5Services.hashPassword(dataUser[0].Password), Login = dataUser[0].Login,
                TypeUsers = "user", PersonalData = { new PersonalDatum() { Date = dataUser[0].Date, Sname = dataUser[0].Sname, Name = dataUser[0].Name, MidellName = dataUser[0].MidellName, Id = dataUser[0].Id, UserId = dataUser[0].Id } } } };
           DbContextProductShop dbContext = new DbContextProductShop();
            dbContext.Users.Add(users[0]);
            dbContext.SaveChanges();
             return Ok("API Validated");
        }

    }
}
